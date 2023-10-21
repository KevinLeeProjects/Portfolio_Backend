using System.Security.Cryptography;
using Npgsql;
using System;
using System.Data;
using System.Text;
using Portfolio_Backend.EFCore;

namespace Portfolio_Backend.Models
{
    public class CreateNewProject
    {
        
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public CreateNewProject(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public bool AddProject(ProjectModel model)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            // Access values
            // Step 1: Create a new database connection
            using (NpgsqlConnection connection = GetDatabaseConnection())
            {
                // Step 2: Prepare and execute the INSERT query
                string query = "INSERT INTO projects (title, route, imgsrc, imgalt, github, skills, desctitle, descriptions, subImages) " +
                               "VALUES (@title, @route, @imgsrc, @imgalt, @github, @skills, @desctitle, @descriptions, @subImages)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Step 3: Set parameters for the query
                    command.Parameters.AddWithValue("@title", model.title);
                    command.Parameters.AddWithValue("@route", model.route);
                    command.Parameters.AddWithValue("@imgsrc", model.imgsrc);
                    command.Parameters.AddWithValue("@imgalt", model.imgalt);
                    command.Parameters.AddWithValue("@github", model.github);
                    command.Parameters.AddWithValue("@skills", model.skills);
                    command.Parameters.AddWithValue("@desctitle", model.desctitle);
                    command.Parameters.AddWithValue("@descriptions", model.descriptions);
                    command.Parameters.AddWithValue("@subImages", model.subImages);

                    // Step 4: Execute the query and get the number of rows affected
                    int rowsAffected = command.ExecuteNonQuery();

                    // Step 5: Return true if rows were affected, indicating success
                    return rowsAffected > 0;
                }
            }
         }
        private NpgsqlConnection GetDatabaseConnection()
        {
            // Create a new database connection
            var databaseHelper = new DatabaseHelper();
            return databaseHelper.GetConnection();
        }
    }
}
