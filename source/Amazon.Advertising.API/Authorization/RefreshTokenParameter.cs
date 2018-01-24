using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Advertising.API.Authorization
{
    public class RefreshTokenParameter
    {
        public string RefreshToken { get; set; }

        /// <summary>
        /// 目前只能传refresh_token
        /// </summary>
        public string GrantType { get; set; } = "refresh_token";

        public string ClientId { get; set; }

        public string SecretId { get; set; }
    }
}
