using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkerCodingTest.DataAccess.Shared
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
