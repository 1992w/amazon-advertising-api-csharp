using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdResponse : BaseResponse
    {
        /// <summary>
        /// The ID of the ad that was created/updated, if successful
        /// </summary>
        [JsonProperty("adId")]
        public long? AdId { get; set; }
    }
}
