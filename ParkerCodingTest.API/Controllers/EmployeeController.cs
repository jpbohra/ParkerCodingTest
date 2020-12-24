using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkerCodingTest.API.Contracts;
using ParkerCodingTest.DataAccess.Employee;
using ParkerCodingTest.Repository.Employee;

namespace ParkerCodingTest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeById(string Id)
        {
            var employee = await _employeeRepo.GetEmployee(Id);

            if (employee == null)
                return NotFound();

            var employeeContract = _mapper.Map<EmployeeModel>(employee);

            return Ok(employeeContract);
        }



        [HttpPost]
        public async Task<IActionResult> SaveEmployee([FromBody] EmployeeContract employeeContract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponseContract()
                {
                    ErrorMessage = "Invalid request",
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest)
                });

            var employeeModel = _mapper.Map<EmployeeModel>(employeeContract);

            var result = await _employeeRepo.SaveEmployee(employeeModel);

            return Ok(result);
        }
    }
}
