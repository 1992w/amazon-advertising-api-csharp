using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class Recommendation
    {
        /// <summary>
        /// The resulting status code for retrieving the bid.
        /// enum: SUCCESS, NOT_FOUND
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The keyword the recommendation was requested for.
        /// </summary>
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// The match type used to match the keyword to search query.
        /// enum: exact, phrase, broad
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }
        
        [JsonProperty("suggestedBid")]
        public SuggestedBid SuggestedBid { get; set; }
    }
}
