using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
    public interface IRepData
    {
        Task InsertRep(RepModelDB representative);
        Task<List<RepModelDB>> GetReps();
    }

    public class RepData : IRepData
    {
        private readonly ISqlDataAccess _db;

        public RepData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task InsertRep(RepModelDB representative)
        {
            string sql = @"insert into dbo.representatives (name, party, urls, emails, office, photoUrl, divisionId) values (@name, @party, @urls, @emails, @office, @photoUrl, @divisionId);";
            return _db.SaveData(sql, representative);
        }

        public Task<List<RepModelDB>> GetReps()
        {
            string sql = "select * from dbo.representatives order by divisionId";
            return _db.LoadData<RepModelDB, dynamic>(sql, new { });
        }

    }
}
