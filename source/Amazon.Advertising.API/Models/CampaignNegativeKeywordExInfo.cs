using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignNegativeKeywordExInfo:CampaignNegativeKeywordInfo
    {
        /// <summary>
        /// The date the ad group was created as epoch time in seconds
        /// </summary>
        [JsonProperty("creationDate")]
        public long? CreationDate { get; set; }

        /// <summary>
        /// The date the ad group was last updated as epoch time in seconds
        /// </summary>
        [JsonProperty("lastUpdatedDate")]
        public long? LastUpdateDate { get; set; }

        /// <summary>
        /// "description": "The computed status, accounting for out of budget, policy violations, etc. See
        ///     developer notes for more information.",
        /// "type": "string",
        /// "oneOf": ["active"]
        /// </summary>
        [JsonProperty("servingStatus")]
        public string ServingStatus { get; set; }
    }
}
