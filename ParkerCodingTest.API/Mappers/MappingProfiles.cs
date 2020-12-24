using AutoMapper;
using ParkerCodingTest.API.Contracts;
using ParkerCodingTest.DataAccess.Employee;

namespace ParkerCodingTest.API.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeContract, EmployeeModel>().ReverseMap();
        }
    }
}
