using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class RequestSnaphotParameter
    {
        /// <summary>
        /// The type of campaign for which snapshot should be generated. 
        /// Must be sponsoredProducts
        /// </summary>
        [JsonProperty("campaignType")]
        public string CampaignType { get; set; }

        /// <summary>
        /// Restricts results to entities with state within the specified comma-
        /// separated list.Must be one of:  enabled , paused , archived.Default
        /// behavior is to include  enabled and  paused.
        /// </summary>
        [JsonProperty]
        public string StateFilter { get; set; }
    }
}
