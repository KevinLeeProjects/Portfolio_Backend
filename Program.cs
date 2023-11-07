using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio_Backend.Models;
using Azure.Identity;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EF_DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                          policy.WithOrigins("https://kevinlee.app").AllowAnyHeader().AllowAnyMethod();
                      });
});

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddAzureKeyVault(
        new Uri("https://databasepass.vault.azure.net/"),
        new DefaultAzureCredential()
    )
    .AddEnvironmentVariables();

var configuration = configBuilder.Build();

var pass = configuration["pass"];
var userId = configuration["userId"];
var db = configuration["db"];
var server = configuration["server"];
var connectionString = $"Server={server};Database={db};Port=5432;User Id={userId};Password={pass};";

// Replace the placeholder in the configuration
configuration["ConnectionStrings:Ef_Postgres_Db"] = connectionString;


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
