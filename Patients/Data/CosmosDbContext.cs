using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Patients.Data
{
    public class CosmosDbContext
    {
        private readonly Database _database;

        public CosmosDbContext(IConfiguration configuration)
        {
            var connectionString = configuration["CosmosDbConnectionString"];

            var client = new CosmosClient(
     "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            _database = client.GetDatabase(
                configuration["CosmosDatabaseName"]);
        }

        public Container PatientsContainer =>
            _database.GetContainer("Users");
    }
}