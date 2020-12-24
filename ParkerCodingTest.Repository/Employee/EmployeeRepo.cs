using ParkerCodingTest.DataAccess.Employee;
using System.Threading.Tasks;

namespace ParkerCodingTest.Repository.Employee
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeRepo(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }
        public async Task<EmployeeModel> SaveEmployee(EmployeeModel employeeModel)
        {
            return await _employeeDataService.Save(employeeModel);
        }

        public async Task<EmployeeModel> GetEmployee(string Id)
        {
            return await _employeeDataService.GetById(Id);
        }
    }
}
