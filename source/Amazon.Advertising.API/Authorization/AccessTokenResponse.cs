using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Authorization
{
    public class AccessTokenResponse
    {
        public bool SuccessFul
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error) == true;
            }
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// token有效时间。单位:s
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_uri")]
        public string ErrorUri { get; set; }
    }
}

