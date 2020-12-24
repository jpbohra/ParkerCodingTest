using System.Threading.Tasks;

namespace ParkerCodingTest.DataAccess.Employee
{
    public interface IEmployeeDataService
    {
        Task<EmployeeModel> GetById(string id);
        Task<EmployeeModel> Save(EmployeeModel employeeModel);
    }
}