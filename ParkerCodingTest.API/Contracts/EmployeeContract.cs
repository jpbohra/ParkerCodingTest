using ParkerCodingTest.DataAccess.Employee;
using System.ComponentModel.DataAnnotations;

namespace ParkerCodingTest.API.Contracts
{
    public class EmployeeContract
    {
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string SecurityQuestion { get; set; }

        [Required]
        public string SecurityAnswer { get; set; }

        [Required]
        public GenderType Gender { get; set; }
    }
}
