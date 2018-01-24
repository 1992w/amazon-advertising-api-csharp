using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class GetAdGroupSuggestedKeywordsExResponse
    {
        /// <summary>
        /// The ID of the requested ad group
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        /// <summary>
        /// The campaign ID in which the ad group belongs to
        /// </summary>
        [JsonProperty("campaignId")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// The suggested keyword
        /// </summary>
        [JsonProperty("keywordText")]
        public string KeywordText { get; set; }

        /// <summary>
        /// Match type of the suggested keyword
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        /// <summary>
        /// The state of the suggested keyword. Should be either enabled or paused
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// The keyword bid suggestion. Will only be shown if suggestBid is 'yes' and the keyword has a bid suggestion
        /// </summary>
        [JsonProperty("bid")]
        public long? Bid { get; set; }
    }
}
