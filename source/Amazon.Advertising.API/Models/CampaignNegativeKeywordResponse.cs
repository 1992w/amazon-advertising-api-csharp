using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class CampaignNegativeKeywordResponse : BaseResponse
    {
        /// <summary>
        /// The ID of the keyword that was created/updated, if successful
        /// </summary>
        [JsonProperty("keywordId")]
        public long? KeywordId { get; set; }
    }
}
