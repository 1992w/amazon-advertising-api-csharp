using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class BaseResponse
    {

        public bool Success
        {
            get
            {
                return this.Code.ToLower() == "success";
            }
        }

        /// <summary>
        /// An enumerated success or error code for machine use.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// A human-readable description of the error, if unsuccessful
        /// </summary>
        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
