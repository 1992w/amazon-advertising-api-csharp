using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Authorization
{
    public class CustomerProfileResponse
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }
}
