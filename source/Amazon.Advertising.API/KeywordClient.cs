using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class KeywordClient : BaseClient
    {
        public KeywordClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves a keyword by ID.
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public KeywordInfo GetBiddableKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/{keywordId}";
            return this.HttpRequest<KeywordInfo>(url);
        }

        /// <summary>
        /// Retrieves a keyword and its extended fields by ID
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public KeywordExInfo GetBiddableKeywordEx(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/extended/{keywordId}";
            return this.HttpRequest<KeywordExInfo>(url);
        }

        /// <summary>
        /// Creates one or more keywords. Successfully created keywords will be assigned unique  keywordIds .
        /// </summary>
        /// <param name="keywords">A list of up to 1000 keywords to be created. Required fields for keyword creation
        /// are:  campaignId ,  adGroupId ,  keywordText ,  matchType , and state</param>
        /// <returns></returns>
        public List<KeywordResponse> CreateBiddableKeywords(List<KeywordInfo> keywords)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords";
            return this.HttpRequest<List<KeywordResponse>>(url, JsonConvert.SerializeObject(keywords), "POST");
        }

        /// <summary>
        /// Updates one or more keywords. Keywords are identified using their  keywordIds . 
        /// </summary>
        /// <param name="keywords">A list of up to 1000 updates containing keywordIds and the mutable fields to be
        /// modified.Mutable fields are:  state ,  enabled ,  paused ,  archived , and bid</param>
        /// <returns></returns>
        public List<KeywordResponse> UpdateBiddableKeywords(List<KeywordInfo> keywords)
        {
            var data = JsonConvert.SerializeObject(
                    keywords,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords";
            return this.HttpRequest<List<KeywordResponse>>(url, data, "PUT");
        }

        /// <summary>
        /// Sets the keyword status to archived. 
        /// </summary>
        /// <param name="keywordId">The ID of the keyword to be archived.</param>
        /// <returns></returns>
        public KeywordResponse ArchiveBiddableKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/{keywordId}";
            return this.HttpRequest<KeywordResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Retrieves a list of keywords satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<KeywordInfo> ListBiddableKeywords(ListBiddableKeywordsParameter parameter = null)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords?{queryData}";
            return this.HttpRequest<List<KeywordInfo>>(url);
        }

        /// <summary>
        /// Retrieves a list of keywords with extended fields satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<KeywordExInfo> ListBiddableKeywordsEx(ListBiddableKeywordsParameter parameter = null)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/extended?{queryData}";
            return this.HttpRequest<List<KeywordExInfo>>(url);
        }

        private static string GenQueryData(ListBiddableKeywordsParameter parameter)
        {
            var queryData = new List<string>();
            if (parameter.StartIndex.HasValue)
                queryData.Add($"startIndex={parameter.StartIndex}");
            if (parameter.Count.HasValue)
                queryData.Add($"count={parameter.Count}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignType))
                queryData.Add($"campaignType={parameter.CampaignType}");
            if (!string.IsNullOrWhiteSpace(parameter.MatchTypeFilter))
                queryData.Add($"matchTypeFilter={parameter.MatchTypeFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.KeywordText))
                queryData.Add($"keywordText={parameter.KeywordText}");
            if (!string.IsNullOrWhiteSpace(parameter.StateFilter))
                queryData.Add($"stateFilter={parameter.StateFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignIdFilter))
                queryData.Add($"campaignIdFilter={parameter.CampaignIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.AdGroupIdFilter))
                queryData.Add($"adGroupIdFilter={parameter.AdGroupIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.KeywordIdFilter))
                queryData.Add($"keywordIdFilter={parameter.KeywordIdFilter}");

            return string.Join("&", queryData);
        }
    }
}
