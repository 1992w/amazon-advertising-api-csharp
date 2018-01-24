using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class KeywordBidRecommendationsData
    {
        /// <summary>
        /// The ID of the ad group.
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        [JsonProperty("keywords")]
        public List<BidKeyword> Keywords { get; set; }
    }

    public class BidKeyword
    {
        /// <summary>
        /// The keyword text.
        /// </summary>
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// The match type used to match the keyword to search query.
        /// enum: exact, phrase, broad
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }
    }
}
