using Newtonsoft.Json;

namespace Amazon.Advertising.API.Authorization
{
    public class VerifyAccessTokenResponse
    {
        [JsonProperty("iss")]
        public string Iss { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("aud")]
        public string Aud { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("exp")]
        public int Exp { get;set;}

        [JsonProperty("iat")]
        public long Iat { get; set; }
    }
}
