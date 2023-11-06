using Microsoft.AspNetCore.Routing;
using System.Reflection.Metadata;
using Npgsql;

namespace Portfolio_Backend.Models
{
	public class CreatePortfolio
	{
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public CreatePortfolio(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public bool AddPortfolio(PortfolioModel model)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            // Access values
            // Step 1: Create a new database connection
            using (NpgsqlConnection connection = GetDatabaseConnection())
            {
                string createTableQuery = $"CREATE TABLE Portfolio " +
                "(route TEXT, skills TEXT, blurb TEXT, frontendGithub TEXT, backendGithub TEXT, mainImg TEXT, " +
                "homePageTitle TEXT, homePageFrontend TEXT, homePageDesktop TEXT, homePageMobile TEXT, " +
                "navBarTitle TEXT, navBarFrontend TEXT, navBarMobileClosed TEXT, navBarMobileOpen TEXT, " +
                "adminTitle TEXT, adminFrontend TEXT, adminBackend TEXT, adminDesktop TEXT, adminMobile TEXT, " +
                "addProjectTitle TEXT, addProjectFrontend TEXT, addProjectBackend TEXT, addProjectDesktop TEXT, addProjectMobile TEXT)";

                using (NpgsqlCommand createTableCommand = new NpgsqlCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery(); // Execute the CREATE TABLE query
                }

                string insertDataQuery = $"INSERT INTO Portfolio (route, skills, blurb, frontendGithub, backendGithub, mainImg, " +
                    "homePageTitle, homePageFrontend, homePageDesktop, homePageMobile, " +
                    "navBarTitle, navBarFrontend, navBarMobileClosed, navBarMobileOpen, " +
                    "adminTitle, adminFrontend, adminBackend, adminDesktop, adminMobile, " +
                    "addProjectTitle, addProjectFrontend, addProjectBackend, addProjectDesktop, addProjectMobile) " +
                    "VALUES (@route, @skills, @blurb, @frontendGithub, @backendGithub, @mainImg, " +
                    "@homePageTitle, @homePageFrontend, @homePageDesktop, @homePageMobile, " +
                    "@navBarTitle, @navBarFrontend, @navBarMobileClosed, @navBarMobileOpen, " +
                    "@adminTitle, @adminFrontend, @adminBackend, @adminDesktop, @adminMobile, " +
                    "@addProjectTitle, @addProjectFrontend, @addProjectBackend, @addProjectDesktop, @addProjectMobile)";

                using (NpgsqlCommand command = new NpgsqlCommand(insertDataQuery, connection))
                {
                    // Step 3: Set parameters for the query
                    command.Parameters.AddWithValue("@route", model.route);
                    command.Parameters.AddWithValue("@skills", model.skills);
                    command.Parameters.AddWithValue("@blurb", model.blurb);
                    command.Parameters.AddWithValue("@frontendGithub", model.frontendGithub);
                    command.Parameters.AddWithValue("@backendGithub", model.backendGithub);
                    command.Parameters.AddWithValue("@mainImg", model.mainImg);

                    command.Parameters.AddWithValue("@homePageTitle", model.homePageTitle);
                    command.Parameters.AddWithValue("@homePageFrontend", model.homePageFrontend);
                    command.Parameters.AddWithValue("@homePageDesktop", model.homePageDesktop);
                    command.Parameters.AddWithValue("@homePageMobile", model.homePageMobile);

                    command.Parameters.AddWithValue("@navBarTitle", model.navBarTitle);
                    command.Parameters.AddWithValue("@navBarFrontend", model.navBarFrontend);
                    command.Parameters.AddWithValue("@navBarMobileClosed", model.navBarMobileClosed);
                    command.Parameters.AddWithValue("@navBarMobileOpen", model.navBarMobileOpen);

                    command.Parameters.AddWithValue("@adminTitle", model.adminTitle);
                    command.Parameters.AddWithValue("@adminFrontend", model.adminFrontend);
                    command.Parameters.AddWithValue("@adminBackend", model.adminBackend);
                    command.Parameters.AddWithValue("@adminDesktop", model.adminDesktop);
                    command.Parameters.AddWithValue("@adminMobile", model.adminMobile);

                    command.Parameters.AddWithValue("@addProjectTitle", model.addProjectTitle);
                    command.Parameters.AddWithValue("@addProjectFrontend", model.addProjectFrontend);
                    command.Parameters.AddWithValue("@addProjectBackend", model.addProjectBackend);
                    command.Parameters.AddWithValue("@addProjectDesktop", model.addProjectDesktop);
                    command.Parameters.AddWithValue("@addProjectMobile", model.addProjectMobile);



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

