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
    public class DBHelper
    {
        private EF_DataContext _context;
        private readonly DatabaseHelper _databaseHelper;

        public DBHelper(EF_DataContext context, DatabaseHelper databaseHelper)
        {
            _context = context;
            _databaseHelper = databaseHelper;
        }

        // It serves the POST/PUT/PATCH
        public bool CheckLogin(LoginModel loginModel)
        {
            {
                Login dbTable = new Login();
                // Create a configuration builder
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                // Access values
                string connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM login;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access the value of the column
                                string DBemail = reader["Email"].ToString();
                                string DBpassword = reader["Password"].ToString();
                                string DBSalt = reader["Salt"].ToString();

                                if (DBemail == loginModel.email)
                                {
                                    var hashed = HashPassword(loginModel.password, DBSalt);
                                    if (hashed == DBpassword)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                return false;
                            }
                        }
                    }
                }
                return false;
            }
        }

            public static string HashPassword(string password, string salt)
        {
            const int keySize = 64;
            const int iterations = 350000;
            // Use given salt to see if passwords match
            byte[] saltArray = Encoding.UTF8.GetBytes(salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            saltArray,
            iterations,
            HashAlgorithmName.SHA512,
            keySize);
            return Convert.ToHexString(hash);
        }
    }
}
