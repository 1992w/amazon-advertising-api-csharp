using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class SuggestedKeywordClient : BaseClient
    {
        public SuggestedKeywordClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {

        }

        /// <summary>
        /// Retrieve suggested keyword data for the specified  adGroupId
        /// </summary>
        /// <param name="adGroupId">The ID of the requested ad group</param>
        /// <param name="maxNumSuggestions">Maximum number of returned suggested keywords. Default is 100,
        /// maximum is 1000</param>
        /// <param name="adStateFilter">Ad state filter (values are comma separated), to filter out the Ads to get
        /// suggested keywords for their ASINs.Valid values are enabled, paused,
        /// and archived. Default values are enabled and paused</param>
        /// <returns></returns>
        public AdGroupSuggestedKeywordsResponse GetAdGroupSuggestedKeywords(
            string adGroupId,
            string maxNumSuggestions = null,
            string adStateFilter = null)
        {
            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(maxNumSuggestions))
                query.Add($"maxNumSuggestions={maxNumSuggestions}");
            if (!string.IsNullOrWhiteSpace(adStateFilter))
                query.Add($"adStateFilter={adStateFilter}");

            var url = $"{APIEndpoint.GetUrl(Marketplace)}/{ApiVersion}/adGroups/{adGroupId}/suggested/keywords?{string.Join("&", query)}";
            return this.HttpRequest<AdGroupSuggestedKeywordsResponse>(url);
        }

        /// <summary>
        /// Retrieve extended suggested keyword data for the specified  adGroupId .
        /// </summary>
        /// <param name="adGroupId">The ID of the requested ad group</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<GetAdGroupSuggestedKeywordsExResponse> GetAdGroupSuggestedKeywordsEx(
            string adGroupId,
            getAdGroupSuggestedKeywordsExParameter parameter = null)
        {
            var query = string.Empty;
            if (parameter != null)
                query = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(Marketplace)}/{ApiVersion}/adGroups/{adGroupId}/suggested/keywords/extended?{query}";
            return this.HttpRequest<List<GetAdGroupSuggestedKeywordsExResponse>>(url);
        }
        private static string GenQueryData(getAdGroupSuggestedKeywordsExParameter parameter)
        {
            var query = new List<string>();
            if (parameter.MaxNumSuggestions.HasValue)
                query.Add($"maxNumSuggestions={parameter.MaxNumSuggestions}");
            if (!string.IsNullOrWhiteSpace(parameter.SuggestBids))
                query.Add($"suggestBids={parameter.SuggestBids}");
            if (!string.IsNullOrWhiteSpace(parameter.AdStateFilter))
                query.Add($"adStateFilter={parameter.AdStateFilter}");

            return string.Join("&", query);
        }

        /// <summary>
        /// Provides suggested keywords for specified ASIN. Suggested keywords are ordered by most effective to least effective.
        /// </summary>
        /// <param name="asinValue">ASIN</param>
        /// <param name="maxNumSuggestions">Maximum number of returned suggested keywords. Default is 100, maximum is 1000</param>
        /// <returns></returns>
        public BulkGetAsinSuggestedKeywordsResponse GetAsinSuggestedKeywords(string asinValue, int maxNumSuggestions = 100)
        {
            var url = $"{APIEndpoint.GetUrl(Marketplace)}/{ApiVersion}/asins/{asinValue}/suggested/keywords?maxNumSuggestions={maxNumSuggestions}";
            return this.HttpRequest<BulkGetAsinSuggestedKeywordsResponse>(url);
        }

        /// <summary>
        /// Provides keyword suggestions for specified list of ASINs. Suggested keywords are ordered by most effective to least effective.
        /// </summary>
        /// <param name="asins">List of ASINs for which keywords are suggested</param>
        /// <param name="maxNumSuggestions">Maximum number of returned suggested keywords. Default is 100, maximum is 1000</param>
        /// <returns></returns>
        public List<BulkGetAsinSuggestedKeywordsResponse> BulkGetAsinSuggestedKeywords(List<string> asins, int maxNumSuggestions = 100)
        {
            var url = $"{APIEndpoint.GetUrl(Marketplace)}/{ApiVersion}/asins/suggested/keywords";
            return this.HttpRequest<List<BulkGetAsinSuggestedKeywordsResponse>>(
                url,
                JsonConvert.SerializeObject(new
                {
                    asins = asins,
                    maxNumSuggestions = maxNumSuggestions
                }), "POST");
        }
    }
}
