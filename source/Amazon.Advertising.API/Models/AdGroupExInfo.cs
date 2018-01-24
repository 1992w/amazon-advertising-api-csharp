using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdGroupExInfo: AdGroupInfo
    {
        /// <summary>
        /// The date the ad group was created as epoch time in seconds
        /// </summary>
        [JsonProperty("creationDate")]
        public long? CreateDate { get; set; }

        /// <summary>
        /// The date the ad group was last updated as epoch time in seconds
        /// </summary>
        [JsonProperty("lastUpdatedDate")]
        public long? LastUpdatedDate { get; set; }

        /// <summary>
        /// "description": "The computed status, accounting for out of budget, policy violations, etc. See
        ///     developer notes for more information.",
        /// "type": "string",
        /// "oneOf": ["archived", "paused", "active", "suspended", "campaignOutOfBudget", campaignPaused,
        ///     campaignArchived, "advertiserOutOfBudget"]
        /// </summary>
        [JsonProperty("servingStatus")]
        public string servingStatus { get; set; }
    }
}
