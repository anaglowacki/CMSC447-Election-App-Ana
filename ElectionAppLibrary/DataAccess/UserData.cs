using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorUI;
using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
    public interface IUserData
    {
        Task<UserModel> UserLogin(UserModel user);
        Task<UserModel> GetUser(UserModel user);
        Task InsertUser(UserModel user);
		Task UpdateAddress(UserModel user);
		Task UpdateEmail(UserModel user);
		Task<List<CandidateModelDB>> GetCandidatesByDistrict(string district);
        Task SaveCandidateForUser(string username, int candidateId);
        Task<List<CandidateModelDB>> GetSavedCandidatesForUser(string username);
        Task DeleteCandidateForUser(string username, int candidateId);
        Task<bool> IsCandidateAlreadySaved(string username, int candidateId);
        Task DeleteAccount(UserModel user);
        Task<List<UserCandidate>> GetNotes(string username);
        Task SaveNotes(string notes, int ID, string username);

    }

    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<UserModel> UserLogin(UserModel user)
        {
            string sql = @"select * from dbo.app_user where username = '" + user.username + "' and password = '" + user.password + "';";
            return _db.LoadDatum<UserModel, dynamic>(sql, new { });
        }

        public Task<UserModel> GetUser(UserModel user)
        {
            string sql = @"select * from dbo.app_user where username = '" + user.username + "';";
            Task<UserModel> test = _db.LoadDatum<UserModel, dynamic>(sql, new { });
            return test;
        }
		public Task InsertUser(UserModel user)
		{
			string sql = @"insert into dbo.app_user (username, password, email) values (@username, @password, @email);";
			return _db.SaveData(sql, user);
		}

        public Task UpdateEmail(UserModel user)
        {
            string sql = @"update dbo.app_user set email=@email where username=@username;";

            return _db.SaveData(sql, user);
        }

        public Task UpdateAddress(UserModel user)
        {
            string sql = @"update dbo.app_user set address=@address where username=@username;";

            return _db.SaveData(sql, user);
        }

		public Task<List<CandidateModelDB>> GetCandidatesByDistrict(string district)
		{
			string sql = "SELECT * FROM Candidates WHERE DistrictNameAndNumber IN (@District, 'State of Maryland')";
			return _db.LoadData<CandidateModelDB, dynamic>(sql, new { District = district });
		}

        public Task SaveCandidateForUser(string username, int candidateId)
        {
            string sql = "INSERT INTO CandidatesByUser (username, candidateId) VALUES (@username, @candidateId)";
            return _db.SaveData(sql, new { username, candidateId });
        }

        public Task<List<CandidateModelDB>> GetSavedCandidatesForUser(string username)
        {
            string sql = @"SELECT c.* 
                           FROM Candidates c
                           INNER JOIN CandidatesByUser cu ON c.Id = cu.candidateId
                           WHERE cu.username = @username";
            return _db.LoadData<CandidateModelDB, dynamic>(sql, new { username });
        }

        public Task DeleteCandidateForUser(string username, int candidateId)
        {
            string sql = "DELETE FROM CandidatesByUser WHERE username = @username AND candidateId = @candidateId";
            return _db.SaveData(sql, new { username, candidateId });
        }

        public async Task<bool> IsCandidateAlreadySaved(string username, int candidateId)
        {
            string sql = "SELECT COUNT(1) FROM CandidatesByUser WHERE username = @username AND candidateId = @candidateId";
            var result = await _db.LoadDatum<int, dynamic>(sql, new { username, candidateId });
            return result > 0;
        }

        public Task DeleteAccount(UserModel user)
		{
            string sql = @"delete from dbo.CandidatesByUser where username=@username";

            _db.SaveData(sql, user);

			sql = @"delete from dbo.app_user where username=@username";

			return _db.SaveData(sql, user);
			
		}

        public Task<List<UserCandidate>> GetNotes(string username)
        {
            string sql = @"select * from dbo.CandidatesByUser where username = @username;";
            return _db.LoadData<UserCandidate, dynamic>(sql, new {username});
        }

        public Task SaveNotes(string notes, int ID, string username)
        {
            string sql = @"update dbo.CandidatesByUser set notes=@notes where username=@username and candidateId=@ID;";

            return _db.SaveData(sql, new {notes, ID, username});
        }
    }
}
