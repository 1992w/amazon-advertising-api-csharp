using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class KeywordBidRecommendationsResponse
    {
        /// <summary>
        /// The ID of the keyword that a bid was requested for.
        /// </summary>
        [JsonProperty("keywordId")]
        public long? KeywordId { get; set; }

        /// <summary>
        /// The ID of the ad group that a bid was requested for.
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }
        
        [JsonProperty("suggestedBid")]
        public SuggestedBid SuggestedBid { get; set; }
    }
}
