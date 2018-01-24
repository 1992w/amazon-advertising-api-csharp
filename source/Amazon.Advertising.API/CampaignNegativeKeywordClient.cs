using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class CampaignNegativeKeywordClient : BaseClient
    {
        public CampaignNegativeKeywordClient(string access_token, Marketplace marketplace, string profileId) 
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves a campaign negative keyword by ID. 
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public CampaignNegativeKeywordInfo GetCampaignNegativeKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords/{keywordId}";
            return this.HttpRequest<CampaignNegativeKeywordInfo>(url);
        }

        /// <summary>
        /// Retrieves a campaign negative keyword and its extended fields by ID.
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public CampaignNegativeKeywordExInfo GetCampaignNegativeKeywordEx(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords/extended/{keywordId}";
            return this.HttpRequest<CampaignNegativeKeywordExInfo>(url);
        }

        /// <summary>
        /// Creates one or more campaign negative keywords. 
        /// Successfully created keywords will be assigned unique  keywordIds 
        /// </summary>
        /// <param name="keywords">A list of up to 1000 campaign negative keywords to be created.
        /// Required fields for keyword creation are:  campaignId ,  keywordText ,
        /// matchType , and state</param>
        /// <returns></returns>
        public List<CampaignNegativeKeywordResponse> CreateCampaignNegativeKeywords(List<CampaignNegativeKeywordInfo> keywords)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords";
            return this.HttpRequest<List<CampaignNegativeKeywordResponse>>(url, JsonConvert.SerializeObject(keywords), "POST");
        }

        /// <summary>
        /// Updates one or more campaign negative keywords. Keywords are identified using their  keywordIds . 
        /// </summary>
        /// <param name="keywords">A list of up to 1000 updates containing keywordIds and the mutable
        /// fields to be modified.Mutable fields:  state</param>
        /// <returns></returns>
        public List<CampaignNegativeKeywordResponse> UpdateCampaignNegativeKeywords(List<CampaignNegativeKeywordInfo> keywords)
        {
            var data = JsonConvert.SerializeObject(
                    keywords,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords";
            return this.HttpRequest<List<CampaignNegativeKeywordResponse>>(url, data, "PUT");
        }

        /// <summary>
        /// Sets the campaign negative keyword status to deleted.
        /// </summary>
        /// <remarks>
        /// While ad group level keywords (both biddable and negative) support paused and archived status, campaign negative 
        /// keywords only support enabled or deleted status.Deleted status indicates permanent removal of the campaign negative 
        /// keyword.Retrieving a deleted entity by ID will result in a 404 error.
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to be deleted</param>
        /// <returns></returns>
        public CampaignNegativeKeywordResponse RemoveCampaignNegativeKeyword(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords/{keywordId}";
            return this.HttpRequest<CampaignNegativeKeywordResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Retrieves a list of negative keywords satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<CampaignNegativeKeywordInfo> ListCampaignNegativeKeywords(
            ListCampaignNegativeKeywordsParameter parameter)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords?{queryData}";
            return this.HttpRequest<List<CampaignNegativeKeywordInfo>>(url);
        }

        /// <summary>
        /// Retrieves a list of campaign negative keywords with extended fields satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<CampaignNegativeKeywordExInfo> ListCampaignNegativeKeywordsEx(
            ListCampaignNegativeKeywordsParameter parameter)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaignNegativeKeywords/extended?{queryData}";
            return this.HttpRequest<List<CampaignNegativeKeywordExInfo>>(url);
        }

        private static string GenQueryData(ListCampaignNegativeKeywordsParameter parameter)
        {
            var queryData = new List<string>();
            if (parameter.StartIndex.HasValue)
                queryData.Add($"startIndex={parameter.StartIndex.Value}");
            if (parameter.Count.HasValue)
                queryData.Add($"count={parameter.Count}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignType))
                queryData.Add($"campaignType={parameter.CampaignType}");
            if (!string.IsNullOrWhiteSpace(parameter.MatchTypeFilter))
                queryData.Add($"matchTypeFilter={parameter.MatchTypeFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.KeywordText))
                queryData.Add($"keywordText={parameter.KeywordText}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignIdFilter))
                queryData.Add($"campaignIdFilter={parameter.CampaignIdFilter}");

            return string.Join("&", queryData);
        }
    }
}
