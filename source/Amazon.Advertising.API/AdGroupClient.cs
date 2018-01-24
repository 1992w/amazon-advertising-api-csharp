using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class AdGroupClient : BaseClient
    {
        public AdGroupClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves an ad group by ID.
        /// </summary>
        /// <param name="adGroupId"></param>
        /// <returns></returns>
        public AdGroupInfo GetAdGroup(string adGroupId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups/{adGroupId}";
            return this.HttpRequest<AdGroupInfo>(url);
        }

        /// <summary>
        /// Retrieves an ad group and its extended fields by ID.
        /// </summary>
        /// <param name="adGroupId"></param>
        /// <returns></returns>
        public AdGroupExInfo GetAdGroupEx(string adGroupId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups/extended/{adGroupId}";
            return this.HttpRequest<AdGroupExInfo>(url);
        }

        /// <summary>
        /// Creates one or more ad groups. Successfully created ad groups will be assigned unique adGroupIds.
        /// </summary>
        /// <param name="adGroups">A list of up to 100 ad groups to be created. Required fields for ad group creation
        /// are:  campaignId ,  name ,  state , and defaultBid</param>
        /// <returns></returns>
        public List<AdGroupResponse> CreateAdGroups(List<AdGroupInfo> adGroups)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups";
            return this.HttpRequest<List<AdGroupResponse>>(url, JsonConvert.SerializeObject(adGroups), "POST");
        }

        /// <summary>
        /// Updates one or more ad groups. Ad groups are identified using their adGroupId.
        /// </summary>
        /// <param name="adGroups">A list of up to 100 updates containing  adGroupIds and the mutable fields to be
        /// modified.Mutable fields are:  name ,  defaultBid , and state</param>
        /// <returns></returns>
        public List<AdGroupResponse> UpdateAdGroups(List<AdGroupInfo> adGroups)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups";
            var data = JsonConvert.SerializeObject(
                    adGroups,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            return this.HttpRequest<List<AdGroupResponse>>(url, data, "PUT");
        }

        /// <summary>
        /// Sets the ad group status to archived.
        /// </summary>
        /// <param name="adGroupId">The ID of the ad group to be archived.</param>
        /// <returns></returns>
        public AdGroupResponse ArchiveAdGroup(string adGroupId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/ adGroups/{adGroupId}";
            return this.HttpRequest<AdGroupResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Retrieves a list of ad groups satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<AdGroupInfo> ListAdGroups(ListAdGroupsParameter parameter = null)
        {
            var query = string.Empty;
            if (parameter != null)
                query = GenListAdGroupsQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups?{query}";
            return this.HttpRequest<List<AdGroupInfo>>(url);
        }

        /// <summary>
        /// Retrieves a list of ad groups with extended fields satisfying optional filtering criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<AdGroupExInfo> ListAdGroupsEx(ListAdGroupsParameter parameter = null)
        {
            var query = string.Empty;
            if (parameter != null)
                query = GenListAdGroupsQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/adGroups/extended?{query}";
            return this.HttpRequest<List<AdGroupExInfo>>(url);
        }

        private static string GenListAdGroupsQueryData(ListAdGroupsParameter parameter)
        {
            var queryData = new List<string>();
            if (parameter.StartIndex.HasValue)
                queryData.Add($"startIndex={parameter.StartIndex.Value}");
            if (parameter.Count.HasValue)
                queryData.Add($"count={parameter.Count}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignType))
                queryData.Add($"campaignType={parameter.CampaignType}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignIdFilter))
                queryData.Add($"campaignIdFilter={parameter.CampaignIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.AdGroupIdFilter))
                queryData.Add($"adGroupIdFilter={parameter.AdGroupIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.StateFilter))
                queryData.Add($"stateFilter={parameter.StateFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.Name))
                queryData.Add($"name={parameter.Name}");

            return string.Join("&", queryData);
        }
    }
}
