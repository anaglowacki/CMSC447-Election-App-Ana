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
		Task<(UserModel user, string errorMessage)> UserLogin(UserModel user);
		Task <UserModel> GetUser(UserModel user);
        Task <string> InsertUser(UserModel user);
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

		public async Task<(UserModel user, string errorMessage)> UserLogin(UserModel user)
		{
            try
            {

				string sql = @"select * from dbo.app_user where username = '" + user.username + "' and password = '" + user.password + "';";
				var result = await _db.LoadDatum<UserModel, dynamic>(sql, new { Username = user.username, Password = user.password });

				if (result != null)
				{
					//Login successful
					return (result, "");
				}
				else
				{
					//Login failed
					return (null, "Invalid username or password");
				}
			}
            catch (Exception)
            {
				//Exception occured
                return (null, "An error occured during the login process. Please try again!");
            }
		}

		public Task<UserModel> GetUser(UserModel user)
		{
			string sql = @"select * from dbo.app_user where username = '" + user.username + "';";
            return _db.LoadDatum<UserModel, dynamic>(sql, new { });
        }
		public async Task<string> InsertUser(UserModel user)
		{
            try
            {
				string sql = @"insert into dbo.app_user (username, password, email, address) values (@username, @password, @email, @address);";
				await _db.SaveData(sql, user);
				return ""; //Success
			}
			catch (Exception)
            {
				return "An error occured while creating the account. It's possible that the username is already taken."; 
			}
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
