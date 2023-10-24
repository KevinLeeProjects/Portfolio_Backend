using Portfolio_Backend.EFCore;
using Npgsql;


namespace Portfolio_Backend.Models
{
    public class GetGames
    {
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public GetGames(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public List<GameModel> GetAllGames()
        {
            {
                List<GameModel> result = new List<GameModel>();
                Login dbTable = new Login();
                // Create a configuration builder
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                // Access values
                string connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM games;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GameModel game = new GameModel
                                {
                                    title = reader["title"].ToString(),
                                    route = reader["route"].ToString(),
                                    imgsrc = reader["imgsrc"].ToString(),
                                    imgalt = reader["imgalt"].ToString(),
                                    github = reader["github"].ToString(),
                                    skills = reader["skills"].ToString(),
                                    desctitle = reader["desctitle"] as string[],
                                    descriptions = reader["descriptions"] as string[],
                                    subImages = reader["subimages"] as string[]
                                };
                                result.Add(game);
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}
