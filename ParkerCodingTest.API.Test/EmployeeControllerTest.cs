using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParkerCodingTest.API.Contracts;
using ParkerCodingTest.API.Controllers;
using ParkerCodingTest.DataAccess.Employee;
using ParkerCodingTest.Repository.Employee;
using System.Threading.Tasks;
using Xunit;

namespace ParkerCodingTest.API.Test
{
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeRepo> _employeeRepo;
        private Mock<IMapper> _mapper;
        private EmployeeController controller;
        public EmployeeControllerTest()
        {
            _employeeRepo = new Mock<IEmployeeRepo>();
            _mapper = new Mock<IMapper>();
            controller = new EmployeeController(_employeeRepo.Object, _mapper.Object);
        }

        [Fact]
        public async Task CreateTest_AddEmployee()
        {
            // Arrange
            var employee = new EmployeeContract
            {

                FirstName = "Test F Name",
                LastName = "Test L Name",
                Email = "test@mail.com",
                Gender = GenderType.Male,
                Password = "UniquePassword",
                Phone = "1234567890",
                SecurityQuestion = "Test Security Question",
                SecurityAnswer = "Test Security Answer"
            };

            // Act
            var result = await controller.SaveEmployee(employee);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
