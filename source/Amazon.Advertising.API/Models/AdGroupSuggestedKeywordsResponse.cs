using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class AdGroupSuggestedKeywordsResponse
    {
        /// <summary>
        /// The ID of the requested ad group.
        /// </summary>
        [JsonProperty("adGroupId")]
        public long? AdGroupId { get; set; }

        /// <summary>
        /// List of suggested keywords.
        /// </summary>
        [JsonProperty("suggestedKeywords")]
        public List<string> SuggestedKeywords { get; set; }
    }
}
