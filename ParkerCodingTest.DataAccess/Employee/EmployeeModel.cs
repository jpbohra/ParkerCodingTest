using ParkerCodingTest.DataAccess.Shared;

namespace ParkerCodingTest.DataAccess.Employee
{
    public class EmployeeModel : BaseModel
    {   
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }

        public GenderType Gender { get; set; }
    }

    public enum GenderType
    {
        Male = 1,
        Female = 2
    }
}
