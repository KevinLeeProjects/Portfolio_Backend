using System;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.IO;

namespace Portfolio_Backend.Models
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            // Create a configuration builder
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            connectionString = configuration.GetConnectionString("Ef_Postgres_Db");
        }

        public NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
