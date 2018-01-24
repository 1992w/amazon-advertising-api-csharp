using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class BidRecommendationsResponse
    {
        /// <summary>
        /// The ID of the ad group
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        [JsonProperty("recommendations")]
        public List<Recommendation> Recommendations { get; set; }
    }
}
