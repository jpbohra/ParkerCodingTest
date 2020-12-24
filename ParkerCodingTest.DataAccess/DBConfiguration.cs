using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkerCodingTest.DataAccess.Employee;
using System.Threading.Tasks;

namespace ParkerCodingTest.DataAccess
{
    public static class DbConfigurations
    {
        public static IServiceCollection AddDbConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICosmosDbCore>(
                InitializeCosmosClientInstanceAsync(
                    configuration.GetSection("CosmosDbSettings"))
                    .GetAwaiter().GetResult());

            services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            return services;
        }

        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        public static async Task<CosmosDbCore> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string account = configurationSection.GetSection("EndPoint").Value;
            string key = configurationSection.GetSection("AccountKey").Value;

            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            CosmosDbCore cosmosDbService = new CosmosDbCore(client, databaseName);

            //_ = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            return cosmosDbService;
        }
    }
}
