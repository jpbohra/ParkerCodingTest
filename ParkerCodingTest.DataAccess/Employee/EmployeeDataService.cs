using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace ParkerCodingTest.DataAccess.Employee
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private const string ContainerName = "Employee";
        private readonly ICosmosDbCore _dbCore;
        public Container _container;

        public EmployeeDataService(ICosmosDbCore dbCore)
        {
            _dbCore = dbCore;
            _container = _dbCore.GetContainer(ContainerName);
        }
        public async Task<EmployeeModel> Save(EmployeeModel employeeModel)
        {
            employeeModel.Id = Guid.NewGuid().ToString();
            employeeModel.CreatedOn = DateTime.Now;


            var response = await _container.CreateItemAsync(employeeModel);
            return response.Resource;
        }
        public async Task<EmployeeModel> GetById(string id)
        {
            try
            {
                ItemResponse<EmployeeModel> response = await _container.ReadItemAsync<EmployeeModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch
            {
                return null;
            }
        }
    }
}
