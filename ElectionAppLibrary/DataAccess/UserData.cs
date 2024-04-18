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
            return _db.LoadDatum<UserModel, dynamic>(sql, new { });
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

    }
}