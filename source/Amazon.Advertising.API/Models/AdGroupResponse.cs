using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdGroupResponse : BaseResponse
    {
        /// <summary>
        /// The ID of the ad group that was created/updated, if successful
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }
    }
}
