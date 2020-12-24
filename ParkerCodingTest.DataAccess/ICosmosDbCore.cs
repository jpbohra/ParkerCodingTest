using Microsoft.Azure.Cosmos;

namespace ParkerCodingTest.DataAccess
{
    public interface ICosmosDbCore
    {
        Container GetContainer(string containerName);
    }
}