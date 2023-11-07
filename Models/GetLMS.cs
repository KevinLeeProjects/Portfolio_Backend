using Portfolio_Backend.EFCore;
using Npgsql;


namespace Portfolio_Backend.Models
{
    public class GetLMS
    {
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public GetLMS(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public List<LMSModel> GetLMSInfo()
        {
            {
                List<LMSModel> result = new List<LMSModel>();
                // Create a configuration builder
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                // Access values
                string connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM librarymanagementsystem;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LMSModel lms = new LMSModel
                                {
                                    route = reader["route"].ToString(),
                                    skills = reader["skills"].ToString(),
                                    blurb = reader["blurb"].ToString(),
                                    github = reader["github"].ToString(),
                                    mainImg = reader["mainimg"].ToString(),
                                    getBookTitle = reader["getbooktitle"].ToString(),
                                    getBookDesc = reader["getbookdesc"].ToString(),
                                    addBookTitle = reader["addBookTitle"].ToString(),
                                    addBookDesc = reader["addBookDesc"].ToString(),
                                    checkoutBookTitle = reader["checkoutBookTitle"].ToString(),
                                    checkoutBookDesc = reader["checkoutBookDesc"].ToString(),
                                    transactionHistoryTitle = reader["transactionHistoryTitle"].ToString(),
                                    transactionHistoryDesc = reader["transactionHistoryDesc"].ToString(),
                                    getBookImg = reader["getBookImg"].ToString(),
                                    addBookImg = reader["addBookImg"].ToString(),
                                    checkoutImg = reader["checkoutImg"].ToString(),
                                    transactionImg = reader["transactionImg"].ToString(),
                                    getUserTitle = reader["getUserTitle"].ToString(),
                                    getUserBlurb = reader["getUserBlurb"].ToString(),
                                    getUserImg = reader["getUserImg"].ToString()
                                };
                                result.Add(lms);
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}
