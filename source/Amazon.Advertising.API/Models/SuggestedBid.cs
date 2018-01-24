using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class SuggestedBid
    {
        /// <summary>
        /// The bid recommendation for the ad group.
        /// </summary>
        [JsonProperty("suggested")]
        public long? Suggested { get; set; }

        /// <summary>
        /// The lower bound bid recommendation.
        /// </summary>
        [JsonProperty("rangeStart")]
        public long? RangeStart { get; set; }

        /// <summary>
        /// The upper bound bid recommendation.
        /// </summary>
        [JsonProperty("rangeEnd")]
        public long? RangeEnd { get; set; }
    }
}
