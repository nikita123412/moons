using Entities;
using Gym.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DAL.DAO
{
    public class OfficeDAO : IOfficeDAO
    {
        private readonly string _connectionString;

        public OfficeDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Gym"].ConnectionString;
        }

        public void AddOffice(Office office)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = $"SET IDENTITY_INSERT [Office] ON INSERT INTO Office (id, Name, Location) VALUES ({new Random().Next(10000, 2000000000)}, N'{office.Name}', {office.Location})";
                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();

                }
                catch
                {
                }
            }
        }

        public void DeleteOffice(string Name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM [Office] WHERE Name = {Name}";
                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();

                }
                catch
                {
                }
            }
        }

        public IEnumerable<Office> GetOffices()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetOffices";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Office
                        {
                            IdOffice = (int)reader["id"],
                            Name = (string)reader["Name"],
                            Location = (string)reader["Location"]
                        };
                    }
                }
            }
        }
    }
}
