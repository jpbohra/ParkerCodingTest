using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkerCodingTest.API.Contracts
{
    public class ErrorResponseContract
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
