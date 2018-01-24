using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class GetAsinSuggestedKeywordsResponse
    {
        /// <summary>
        /// The ASIN for which a keyword suggestion is requested
        /// </summary>
        [JsonProperty("asin")]
        public string Asin { get; set; }

        /// <summary>
        /// List of suggested keywords
        /// </summary>
        [JsonProperty("suggestedKeywords")]
        public List<SuggestedKeyword> SuggestedKeywords { get; set; }
    }
}
