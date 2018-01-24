using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class BidRecommendationClient : BaseClient
    {
        public BidRecommendationClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieve bid recommendation data for the specified ad group Id.
        /// </summary>
        /// <param name="adGroupId">The ID of the requested ad group</param>
        /// <returns></returns>
        public AdGroupBidRecommendationsResponse GetAdGroupBidRecommendations(string adGroupId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups/{adGroupId}/bidRecommendations";
            return this.HttpRequest<AdGroupBidRecommendationsResponse>(url);
        }

        /// <summary>
        /// Retrieve bid recommendation data for the specified keyword ID.
        /// </summary>
        /// <param name="keywordId">The ID of the requested keyword</param>
        /// <returns></returns>
        public KeywordBidRecommendationsResponse GetKeywordBidRecommendations(string keywordId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/{keywordId}/bidRecommendations";
            return this.HttpRequest<KeywordBidRecommendationsResponse>(url);
        }

        /// <summary>
        /// Retrieve keyword bid recommendation data for one or more keywords.
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public List<BidRecommendationsResponse> GetKeywordBidRecommendations(List<KeywordBidRecommendationsData> datas)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/keywords/bidRecommendations";
            return this.HttpRequest<List<BidRecommendationsResponse>>(url, JsonConvert.SerializeObject(datas), "POST");
        }
    }
}
