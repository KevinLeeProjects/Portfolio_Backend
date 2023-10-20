using Portfolio_Backend.EFCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using Npgsql;
using System;
using System.Data;
using System.Text;

namespace Portfolio_Backend.Models
{
    public class GetProjects
    {
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public GetProjects(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public List<ProjectModel> GetAllProjects()
        {
            {
                List<ProjectModel> result = new List<ProjectModel>();
                Login dbTable = new Login();
                // Create a configuration builder
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                // Access values
                string connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM projects;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProjectModel project = new ProjectModel
                                {
                                    title = reader["title"].ToString(),
                                    route = reader["route"].ToString(),
                                    imgsrc = reader["imgsrc"].ToString(),
                                    imgalt = reader["imgalt"].ToString(),
                                    github = reader["github"].ToString(),
                                    skills = reader["skills"].ToString(),
                                    descriptions = reader["descriptions"] as string[],
                                    subImages = reader["subimages"] as string[]
                                };
                                result.Add(project);
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}
