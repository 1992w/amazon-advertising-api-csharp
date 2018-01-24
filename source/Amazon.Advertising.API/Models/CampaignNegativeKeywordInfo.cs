using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignNegativeKeywordInfo
    {
        /// <summary>
        /// The ID of the keyword.
        /// </summary>
        [JsonProperty("keywordId")]
        public long? KeywordId { get; set; }

        /// <summary>
        /// The ID of the campaign to which this keyword belongs.
        /// </summary>
        [JsonProperty("campaignId")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// "description": "Advertiser-specified state of the keyword",
        /// "type": "string",
        /// "oneOf": ["enabled", "deleted"]
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// The expression to match against search queries
        /// </summary>
        [JsonProperty("keywordText")]
        public string KeywordText { get; set; }

        /// <summary>
        /// "description": "The match type used to match the keyword to search query",
        /// "type": "string",
        /// "oneOf": ["negativeExact", "negativePhrase"]
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }
    }
}
