using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class KeywordInfo
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
        /// The ID of the campaign to which this keyword belongs. Specified for ad group
        /// level keywords.
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        /// <summary>
        /// "description": "Advertiser-specified state of the keyword",
        /// "type": "string",
        /// "oneOf": ["enabled", "paused", "archived"]
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// "description": "The expression to match against search queries",
        /// "type": "string",
        /// </summary>
        [JsonProperty("keywordText")]
        public string KeywordText { get; set; }

        /// <summary>
        /// "description": "The match type used to match the keyword to search query",
        /// "type": "string",
        /// "oneOf": ["exact", "phrase", "broad"]
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        /// <summary>
        /// "description": "Bid used when ads are sourced using this keyword. Only compatible with biddable
        ///     match types.",
        /// "type": "number",
        /// "minimum": 0.02,
        /// </summary>
        [JsonProperty("bid")]
        public float? Bid { get; set; }
    }
}
