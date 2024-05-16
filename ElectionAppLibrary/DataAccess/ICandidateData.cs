using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
	public interface ICandidateData
	{
		Task InsertCandidate(CandidateModelDB candidate);
		Task<List<CandidateModelDB>> GetCandidates();
        Task<bool> IsCandidateInDB(CandidateModelDB candidate);
    }

	public class CandidateData : ICandidateData
	{
		private readonly ISqlDataAccess _db;

		public CandidateData(ISqlDataAccess db)
		{
			_db = db;
		}

		public Task InsertCandidate(CandidateModelDB candidate)
		{
			string sql = @"
                INSERT INTO Candidates (
                    OfficeName, 
                    DistrictNameAndNumber, 
                    CandidateLastName, 
                    CandidateFirstName, 
                    PoliticalParty, 
                    CandidateStatus, 
                    PublicPhone, 
                    Email, 
                    Website, 
                    Facebook, 
                    Twitter, 
                    Other) 
                VALUES (
                    @OfficeName, 
                    @DistrictNameAndNumber, 
                    @CandidateLastName, 
                    @CandidateFirstName, 
                    @PoliticalParty, 
                    @CandidateStatus, 
                    @PublicPhone, 
                    @Email, 
                    @Website, 
                    @Facebook, 
                    @Twitter, 
                    @Other);";

			return _db.SaveData(sql, candidate);
		}

		public Task<List<CandidateModelDB>> GetCandidates()
		{
			string sql = "SELECT * FROM Candidates ORDER BY DistrictNameAndNumber";
			return _db.LoadData<CandidateModelDB, dynamic>(sql, new { });
		}

        public async Task<bool> IsCandidateInDB(CandidateModelDB candidate)
        {
            string sql = @"SELECT COUNT(1) FROM Candidates 
                           WHERE CandidateFirstName = @CandidateFirstName 
                             AND CandidateLastName = @CandidateLastName 
                             AND OfficeName = @OfficeName 
                             AND PoliticalParty = @PoliticalParty";
            var result = await _db.LoadDatum<int, dynamic>(sql, new
            {
                candidate.CandidateFirstName,
                candidate.CandidateLastName,
                candidate.OfficeName,
                candidate.PoliticalParty
            });
            return result > 0;
        }
    }
}