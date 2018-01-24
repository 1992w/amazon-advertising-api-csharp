using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignInfo
    {
        /// <summary>
        /// The ID of the campaign
        /// </summary>
        [JsonProperty("campaignId")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// The name of the campaign
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// "description": "Specifies the advertising product managed by this campaign",
        /// "type": "string",
        /// "oneOf": ["sponsoredProducts"]
        /// </summary>
        [JsonProperty("campaignType")]
        public string CampaignType { get; set; }

        /// <summary>
        /// "description": "Differentiates between a keyword-targeted and automatically targeted campaign",
        /// "type": "string",
        /// "oneOf": ["manual", "auto"]
        /// </summary>
        [JsonProperty("targetingType")]
        public string TargetingType { get; set; }

        /// <summary>
        /// When enabled, Amazon will increase the default bid for your ads that are
        /// eligible to appear in this placement.See developer notes for more information.
        /// </summary>
        [JsonProperty("premiumBidAdjustment")]
        public bool? PremiumBidAdjustment { get; set; }

        /// <summary>
        /// Daily budget for the campaign in dollars
        /// </summary>
        [JsonProperty("dailyBudget")]
        public float? DailyBudget { get; set; }

        /// <summary>
        /// The date the campaign will go or went live as YYYYMMDD
        /// </summary>
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// The optional date the campaign will stop running as YYYYMMDD
        /// </summary>
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// "description": "Advertiser-specified state of the campaign",
        /// "type": "string",
        /// "oneOf": ["enabled", "paused", "archived"]
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
