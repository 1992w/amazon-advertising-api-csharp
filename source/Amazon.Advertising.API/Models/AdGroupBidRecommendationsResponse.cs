using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdGroupBidRecommendationsResponse
    {
        /// <summary>
        /// The ID of the ad group that a bid was requested for.
        /// </summary>
        [JsonProperty("adGroupId")]
        public string AdGroupId { get; set; }

        [JsonProperty("suggestedBid")]
        public SuggestedBid SuggestedBid { get; set; }
    }
}
