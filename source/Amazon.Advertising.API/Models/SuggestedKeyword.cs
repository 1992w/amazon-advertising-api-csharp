using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class SuggestedKeyword
    {
        /// <summary>
        /// The suggested keyword
        /// </summary>
        [JsonProperty("keywordText")]
        public string KeywordText { get; set; }

        /// <summary>
        /// Match type of the suggested keyword
        /// </summary>
        [JsonProperty("matchType")]
        public string MatchType { get; set; }
    }
}
