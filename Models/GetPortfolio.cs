using Portfolio_Backend.EFCore;
using Npgsql;

namespace Portfolio_Backend.Models
{
	public class GetPortfolio
	{
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public GetPortfolio(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public List<PortfolioModel> GetPortfolioInfo()
        {
            {
                List<PortfolioModel> result = new List<PortfolioModel>();
                // Create a configuration builder
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                // Access values
                string connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM portfolio;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PortfolioModel portfolio = new PortfolioModel
                                {
                                    route = reader["route"].ToString(),
                                    skills = reader["skills"].ToString(),
                                    blurb = reader["blurb"].ToString(),
                                    frontendGithub = reader["frontendgithub"].ToString(),
                                    backendGithub = reader["backendgithub"].ToString(),
                                    mainImg = reader["mainimg"].ToString(),
                                    homePageTitle = reader["homepageTitle"].ToString(),
                                    homePageFrontend = reader["homepagefrontend"].ToString(),
                                    homePageDesktop = reader["homepagedesktop"].ToString(),
                                    homePageMobile = reader["homepagemobile"].ToString(),
                                    navBarTitle = reader["navbartitle"].ToString(),
                                    navBarFrontend = reader["navbarfrontend"].ToString(),
                                    navBarMobileClosed = reader["navbarmobileclosed"].ToString(),
                                    navBarMobileOpen = reader["navbarmobileopen"].ToString(),
                                    adminTitle = reader["admintitle"].ToString(),
                                    adminFrontend = reader["adminfrontend"].ToString(),
                                    adminBackend = reader["adminbackend"].ToString(),
                                    adminDesktop = reader["admindesktop"].ToString(),
                                    adminMobile = reader["adminmobile"].ToString(),
                                    addProjectTitle = reader["addprojecttitle"].ToString(),
                                    addProjectFrontend = reader["addprojectfrontend"].ToString(),
                                    addProjectBackend = reader["addprojectbackend"].ToString(),
                                    addProjectDesktop = reader["addprojectdesktop"].ToString(),
                                    addProjectMobile = reader["addprojectmobile"].ToString()
                                };
                                result.Add(portfolio);
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}

