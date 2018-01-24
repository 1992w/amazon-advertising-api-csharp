using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignExInfo : CampaignInfo
    {
        /// <summary>
        /// The computed status, accounting for campaign out of budget, policy violations,
        /// etc.See developer notes for more information.
        /// </summary>
        [JsonProperty("servingStatus")]
        public string ServingStatus { get; set; }

        /// <summary>
        /// The date the campaign was created as epoch time in milliseconds
        /// </summary>
        [JsonProperty("creationDate")]
        public long? CreationDate { get; set; }

        /// <summary>
        /// The date the campaign was last updated as epoch time in milliseconds
        /// </summary>
        [JsonProperty("lastUpdatedDate")]
        public long? LastUpdatedDate { get; set; }
    }
}
