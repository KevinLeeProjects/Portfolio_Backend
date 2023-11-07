using Npgsql;

namespace Portfolio_Backend.Models
{
    public class CreateLMS
    {
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public CreateLMS(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        public bool AddLMS(LMSModel model)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            // Access values
            // Step 1: Create a new database connection
            using (NpgsqlConnection connection = GetDatabaseConnection())
            {
                string createTableQuery = $"CREATE TABLE LibraryManagementSystem " +
                "(route TEXT, skills TEXT, blurb TEXT, github TEXT, mainImg TEXT, " +
                "getBookTitle TEXT, getBookDesc TEXT, addBookTitle TEXT, addBookDesc TEXT, " +
                "checkoutBookTitle TEXT, checkoutBookDesc TEXT, transactionHistoryTitle TEXT, transactionHistoryDesc TEXT, " +
                "getBookImg TEXT, addBookImg TEXT, checkoutImg TEXT, transactionImg TEXT, getUserTitle TEXT, " +
                "getUserBlurb TEXT, getUserImg TEXT)";

                using (NpgsqlCommand createTableCommand = new NpgsqlCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery(); // Execute the CREATE TABLE query
                }

                string insertDataQuery = $"INSERT INTO LibraryManagementSystem (route, skills, blurb, github, mainImg, " +
                    "getBookTitle, getBookDesc, addBookTitle, addBookDesc, " +
                    "checkoutBookTitle, checkoutBookDesc, transactionHistoryTitle, transactionHistoryDesc, " +
                    "getBookImg, addBookImg, checkoutImg, transactionImg, getUserTitle, " +
                    "getUserBlurb, getUserImg) " +
                    "VALUES (@route, @skills, @blurb, @github, @mainImg, " +
                    "@getBookTitle, @getBookDesc, @addBookTitle, @addBookDesc, " +
                    "@checkoutBookTitle, @checkoutBookDesc, @transactionHistoryTitle, @transactionHistoryDesc, " +
                    "@getBookImg, @addBookImg, @checkoutImg, @transactionImg, @getUserTitle, " +
                    "@getUserBlurb, @getUserImg)";

                using (NpgsqlCommand command = new NpgsqlCommand(insertDataQuery, connection))
                {
                    // Step 3: Set parameters for the query
                    command.Parameters.AddWithValue("@route", model.route);
                    command.Parameters.AddWithValue("@skills", model.skills);
                    command.Parameters.AddWithValue("@blurb", model.blurb);
                    command.Parameters.AddWithValue("@github", model.github);
                    command.Parameters.AddWithValue("@mainImg", model.mainImg);

                    command.Parameters.AddWithValue("@getBookTitle", model.getBookTitle);
                    command.Parameters.AddWithValue("@getBookDesc", model.getBookDesc);
                    command.Parameters.AddWithValue("@addBookTitle", model.addBookTitle);
                    command.Parameters.AddWithValue("@addBookDesc", model.addBookDesc);

                    command.Parameters.AddWithValue("@checkoutBookTitle", model.checkoutBookTitle);
                    command.Parameters.AddWithValue("@checkoutBookDesc", model.checkoutBookDesc);
                    command.Parameters.AddWithValue("@transactionHistoryTitle", model.transactionHistoryTitle);
                    command.Parameters.AddWithValue("@transactionHistoryDesc", model.transactionHistoryDesc);

                    command.Parameters.AddWithValue("@getBookImg", model.getBookImg);
                    command.Parameters.AddWithValue("@addBookImg", model.addBookImg);
                    command.Parameters.AddWithValue("@checkoutImg", model.checkoutImg);
                    command.Parameters.AddWithValue("@transactionImg", model.transactionImg);
                    command.Parameters.AddWithValue("@getUserTitle", model.getUserTitle);

                    command.Parameters.AddWithValue("@getUserBlurb", model.getUserBlurb);
                    command.Parameters.AddWithValue("@getUserImg", model.getUserImg);



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
