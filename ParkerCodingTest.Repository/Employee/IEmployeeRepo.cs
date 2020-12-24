using ParkerCodingTest.DataAccess.Employee;
using System.Threading.Tasks;

namespace ParkerCodingTest.Repository.Employee
{
    public interface IEmployeeRepo
    {
        Task<EmployeeModel> SaveEmployee(EmployeeModel employeeModel);

        Task<EmployeeModel> GetEmployee(string Id);
    }
}
