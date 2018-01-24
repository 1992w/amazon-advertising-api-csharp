using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class ProductAdInfo
    {
        /// <summary>
        /// The ID of the product ad.
        /// </summary>
        [JsonProperty("adId")]
        public long? AdId { get; set; }

        /// <summary>
        /// The ID of the campaign to which this product ad belongs
        /// </summary>
        [JsonProperty("campaignId")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// The ID of the ad group to which this product ad belongs
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        /// <summary>
        /// The SKU for the listed product to be advertised. Either this or the asin must be present.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// The ASIN for the listed product to be advertised
        /// </summary>
        [JsonProperty("asin")]
        public string Asin { get; set; }

        /// <summary>
        /// "description": "Advertiser-specified state of the product ad"
        /// "oneOf": ["enabled", "paused", "archived"]
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
