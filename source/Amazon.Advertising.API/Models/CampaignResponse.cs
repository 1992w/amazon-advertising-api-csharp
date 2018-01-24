using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignResponse : BaseResponse
    {
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }
    }
}
