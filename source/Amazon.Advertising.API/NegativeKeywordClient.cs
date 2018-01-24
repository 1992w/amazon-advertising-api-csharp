using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class NegativeKeywordClient : BaseClient
    {
        public NegativeKeywordClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves a negative keyword by ID. 
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public NegativeKeywordInfo GetNegativeKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords/{keywordId}";
            return this.HttpRequest<NegativeKeywordInfo>(url);
        }

        /// <summary>
        /// Retrieves a negative keyword and its extended fields by ID. 
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public NegativeKeywordExInfo GetNegativeKeywordEx(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords/extended/{keywordId}";
            return this.HttpRequest<NegativeKeywordExInfo>(url);
        }

        /// <summary>
        /// Creates one or more negative keywords. Successfully created keywords will be assigned unique  keywordIds 
        /// </summary>
        /// <param name="keywords">
        /// A list of up to 1000 negative keywords to be created. Required fields for
        /// keyword creation are:  campaignId ,  adGroupId ,  keywordText ,  matchType , and state
        /// </param>
        /// <returns></returns>
        public List<NegativeKeywordResponse> CreateNegativeKeywords(List<NegativeKeywordInfo> keywords)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords";
            return this.HttpRequest<List<NegativeKeywordResponse>>(url, JsonConvert.SerializeObject(keywords), "POST");
        }

        /// <summary>
        /// Updates one or more negative keywords. Keywords are identified using their  keywordIds . 
        /// </summary>
        /// <param name="keywords">A list of up to 1000 updates containing keywordIds and the mutable fields to be
        /// modified.Mutable fields:  state ,  enabled , and disabled</param>
        /// <returns></returns>
        public List<NegativeKeywordResponse> UpdateNegativeKeywords(List<NegativeKeywordInfo> keywords)
        {
            var data = JsonConvert.SerializeObject(
                    keywords,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords";
            return this.HttpRequest<List<NegativeKeywordResponse>>(url, data, "PUT");
        }

        /// <summary>
        /// Sets the negative keyword status to archived. 
        /// </summary>
        /// <param name="keywordId">The ID of the keyword to be archived.</param>
        /// <returns></returns>
        public NegativeKeywordResponse ArchiveNegativeKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords/{keywordId}";
            return this.HttpRequest<NegativeKeywordResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Retrieves a list of negative keywords satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<NegativeKeywordInfo> ListNegativeKeywords(ListNegativeKeywordsParameter parameter)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords?{queryData}";
            return this.HttpRequest<List<NegativeKeywordInfo>>(url);
        }

        /// <summary>
        /// Retrieves a list of negative keywords with extended fields satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<NegativeKeywordExInfo> ListNegativeKeywordsEx(ListNegativeKeywordsParameter parameter)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/negativeKeywords/extended?{queryData}";
            return this.HttpRequest<List<NegativeKeywordExInfo>>(url);
        }

        private static string GenQueryData(ListNegativeKeywordsParameter parameter)
        {
            var queryData = new List<string>();
            if (parameter.StartIndex.HasValue)
                queryData.Add($"startIndex={parameter.StartIndex}");
            if (parameter.Count.HasValue)
                queryData.Add($"count={parameter.Count}");
            if (string.IsNullOrWhiteSpace(parameter.CampaignType))
                queryData.Add($"campaignType={parameter.CampaignType}");
            if (string.IsNullOrWhiteSpace(parameter.MatchTypeFilter))
                queryData.Add($"matchTypeFilter={parameter.MatchTypeFilter}");
            if (string.IsNullOrWhiteSpace(parameter.KeywordText))
                queryData.Add($"keywordText={parameter.KeywordText}");
            if (string.IsNullOrWhiteSpace(parameter.StateFilter))
                queryData.Add($"stateFilter={parameter.StateFilter}");
            if (string.IsNullOrWhiteSpace(parameter.CampaignIdFilter))
                queryData.Add($"campaignIdFilter={parameter.CampaignIdFilter}");
            if (string.IsNullOrWhiteSpace(parameter.AdGroupIdFilter))
                queryData.Add($"adGroupIdFilter={parameter.AdGroupIdFilter}");

            return string.Join("&", queryData);
        }
    }
}
