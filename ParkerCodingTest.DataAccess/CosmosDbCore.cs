using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkerCodingTest.DataAccess
{
    public class CosmosDbCore : ICosmosDbCore
    {
        private readonly CosmosClient _dbClient;

        public string _dbName { get; set; }

        /// <summary>
        /// Intialize CosmosDbClient and database name
        /// </summary>
        /// <param name="dbClient"></param>
        /// <param name="databaseName"></param>
        public CosmosDbCore(
            CosmosClient dbClient,
            string databaseName)
        {
            _dbClient = dbClient;
            _dbName = databaseName;
        }

        /// <summary>
        /// Get Container Instance
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Container GetContainer(string containerName)
        {
            return _dbClient.GetContainer(_dbName, containerName);
        }
    }
}
