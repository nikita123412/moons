using Entities;
using Gym.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Gym.DAL.DAO
{
    public class AdministratorDao : IAdministratorDAO
    {
        private readonly string _connectionString;

        public AdministratorDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Gym"].ConnectionString;
        }

        public void AddAdministrator(Administrator administrator)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = $"SET IDENTITY_INSERT [Administrator] ON INSERT INTO Administrator (id, Name, id_office) VALUES ({new Random().Next(10000, 2000000000)}, N'{administrator.Name}', {new Random().Next(10000, 2000000000)})";
                try
                {
                    connection.Open();
                    //SqlCommand sqlCommand2 = new SqlCommand("SET IDENTITY_INSERT [Administrator] ON", sqlConnection);
                    //sqlCommand2.ExecuteNonQuery();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();
                    
                }
                catch
                {
                }
            }
        }

        public void DeleteAdministrator(string Name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM [Administrator] WHERE Name = {Name}";
                try
                {
                    connection.Open();
                    //SqlCommand sqlCommand2 = new SqlCommand("SET IDENTITY_INSERT [Administrator] ON", sqlConnection);
                    //sqlCommand2.ExecuteNonQuery();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();

                }
                catch
                {
                }
            }
        }

        public IEnumerable<Administrator> GetAdministrators()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAdministrator";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Administrator
                        {
                            IdAdministrator = (int)reader["id"],
                            Name = (string)reader["Name"]
                        };
                    }
                }
            }
        }
    }
}
