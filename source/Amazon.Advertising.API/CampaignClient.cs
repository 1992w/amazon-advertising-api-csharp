using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class CampaignClient:BaseClient
    {
        public CampaignClient(string access_token, Marketplace marktplace, string profileId)
            : base(access_token, marktplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves a campaign by ID.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public CampaignInfo GetCampaign(string campaignId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns/{campaignId}";
            return this.HttpRequest<CampaignInfo>(url);
        }

        /// <summary>
        /// Retrieves a campaign and its extended fields by ID.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public CampaignExInfo GetCampaignEx(string campaignId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns/extended/{campaignId}";
            return this.HttpRequest<CampaignExInfo>(url);
        }

        /// <summary>
        /// Retrieves a list of campaigns satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IEnumerable<CampaignInfo> ListCampaigns(ListCampaignsParameter parameter = null)
        {
            var query = string.Empty;
            if (parameter != null)
                query = this.GenListCampaignsQueryParameter(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns?{query}";
            return this.HttpRequest<IEnumerable<CampaignInfo>>(url);
        }

        /// <summary>
        /// Sets the campaign status to archived.
        /// </summary>
        /// <param name="campaignId"></param>
        public CampaignResponse ArchiveCampaign(string campaignId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns/{campaignId}";
            return this.HttpRequest<CampaignResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Creates one or more campaigns. Successfully created campaigns will be assigned unique  campaignIds .
        /// A list of up to 100 campaigns to be created. Required fields for campaign creation
        /// are name, campaignType, targetingType, state, dailyBudget and startDate.
        /// </summary>
        /// <param name="campaigns"></param>
        public List<CampaignResponse> CreateCampaigns(List<CampaignInfo> campaigns)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns";
            return this.HttpRequest<List<CampaignResponse>>(url, JsonConvert.SerializeObject(campaigns), "POST");
        }

        /// <summary>
        /// Updates one or more campaigns. Campaigns are identified using their  campaignIds .
        /// A list of up to 100 updates containing  campaignIds and the mutable fields to be modified.
        /// List of mutable fields:  name ,  state ,  dailyBudget ,  startDate ,  endDate ,
        /// premiumBidAdjustment
        /// </summary>
        /// <param name="campaigns"></param>
        /// <returns></returns>
        public List<CampaignResponse> UpdateCampaigns(List<CampaignInfo> campaigns)
        {
            var data = JsonConvert.SerializeObject(
                    campaigns,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/campaigns";
            return this.HttpRequest<List<CampaignResponse>>(url, data, "PUT");
        }

        private string GenListCampaignsQueryParameter(ListCampaignsParameter parameter)
        {
            var query = new List<string>();
            if (string.IsNullOrWhiteSpace(parameter.CampaignType) == false)
                query.Add($"campaignType={parameter.CampaignType}");
            if (parameter.StartIindex.HasValue)
                query.Add($"startIndex={parameter.StartIindex.Value}");
            if (parameter.Count.HasValue)
                query.Add($"count={parameter.Count.Value}");
            if (string.IsNullOrWhiteSpace(parameter.StateFilter) == false)
                query.Add($"stateFilter={parameter.StateFilter}");
            if (string.IsNullOrWhiteSpace(parameter.Name) == false)
                query.Add($"name={parameter.Name}");
            if (string.IsNullOrWhiteSpace(parameter.CampaignIdFilter) == false)
                query.Add($"campaignIdFilter={parameter.CampaignIdFilter}");

            return string.Join("&", query);
        }
    }
}
