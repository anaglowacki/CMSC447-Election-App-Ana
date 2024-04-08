using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectionAppLibrary.Models;

namespace ElectionAppLibrary.DataAccess
{
	public class UserData
	{
		private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<UserModel>> GetUsers(UserModel user)
        {
            string sql = "select * from dbo.app_user where dbo.app_user.username = @username";
			return _db.LoadData<UserModel, dynamic>(sql, new { });
		}
    }
}
