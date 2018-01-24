using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdGroupInfo
    {
        /// <summary>
        /// The ID of the ad group.
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        /// <summary>
        /// The name of the ad group.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the campaign to which this ad group belongs.
        /// </summary>
        [JsonProperty("campaignId")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// The bid used when keywords belonging to this ad group don’t specify a bid.
        /// mininum: 0.02
        /// </summary>
        [JsonProperty("defaultBid")]
        public float? DefaultBid { get; set; }

        /// <summary>
        /// "description": "Advertiser-specified state of the ad group",
        /// "type": "string",
        /// "oneOf": ["enabled", "paused", "archived"]
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
