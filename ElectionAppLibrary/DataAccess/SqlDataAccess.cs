using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Library to create the connection between C# and the SQL database
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; // Library to read configuration settings from C# apps. 
using Dapper;
/*
 * Dapper is an ORM (Object Relational Mapper) library that takes data from the database and converts it into C# objects.
 * Dapper also allows the creation of custom SQL statements from C# to SQL Server
 */


namespace ElectionAppLibrary.DataAccess
{

    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters); // LoadData() conducts a READ operation onto the database and stores the records into a model/class. Method returns a list of rows in a form of 'T' models/objects
        Task<T> LoadDatum<T, U>(string sql, U parameters); // similar to LoadData(), but LoadDatum() will only read the first row in the table
        Task SaveData<T>(string sql, T parameters); // SaveData() will create a custom query from C# and execute that query in SQL Server. Is used for CREATE, UPDATE, and DELETE operations
    }

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config; // "IConfiguration" is from the "Microsoft.Extensions.Configuration" library 

        public string ConnectionStringName { get; set; } = "Default"; // read from the "Default" key in appsettings.json
        public SqlDataAccess(IConfiguration config)
        {
            /*
             * "Constructor Injection." The most basic dependency injection
             * dependency injection means to allow any calls of "_config" to be completely independent from one another every time SqlDataAccess.cs is used
             */
            _config = config; 
        }

        
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters) 
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            /*
             * Explanation of following terms by Preston Viado:
             * 
             * - "IDbConnection" is an interface from the "Dapper" NuGet Package. 
             * This interface allows the developer to create and execute a custom query in C# onto an existing database
             * 
             * "SqlConnection" is a class from the "System.Data.SqlClient" library.
             * This is used to create a new instance of connection to the SQL Server database
             * 
             * - 'T' is the model/class that the record will be stored in
             * 
             * - "data" is variable that will contain the rows that are read from the table. 
             * Each row is read and stored as a 'T' model/class
             * Within the 'T' model/class, all attributes in a row (Ex. Id, FirstName, LastName) are stored
             * 
             * - "QueryAsync" is from the "Dapper" NuGet Package. 
             * This method creates and executes a query from a SQL statement made in C#, called "sql," along with its "parameters"
             * 
             */
            using (IDbConnection connection = new SqlConnection(connectionString)) // connect to the database through connection string
            {
                var data = await connection.QueryAsync<T>(sql, parameters); // Read and store rows that best fits the "parameters" into a list of 'T' objects called "data"

                return data.ToList(); // return a list of 'T' models/objects
            }
        }

        
        public async Task<T> LoadDatum<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString)) // connect to the database through connection string
            {
                try
                {
                    var data = await connection.QueryFirstAsync<T>(sql, parameters); // Read the first row that best of the table that best fits the parameters
                    return data;
                }
                catch (Exception ex)
                {
                    return default;
                }
                
            }
        }

        
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString)) // connect to the database through connection string
            {
                try
                {
                    await connection.ExecuteAsync(sql, parameters); // create and execute the custom sql statement here
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
