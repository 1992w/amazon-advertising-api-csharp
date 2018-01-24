using System.Collections.Generic;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class ProductAdClient : BaseClient
    {
        public ProductAdClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Retrieves a product ad by ID.
        /// </summary>
        /// <param name="adId">The ID of the requested product ad</param>
        /// <returns></returns>
        public ProductAdInfo GetProductAd(string adId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds/{adId}";
            return this.HttpRequest<ProductAdInfo>(url);
        }

        /// <summary>
        /// Retrieves a product ad and its extended fields by ID.
        /// </summary>
        /// <param name="adId">The ID the reuqested product ad</param>
        /// <returns></returns>
        public ProductAdExInfo GetProductAdEx(string adId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds/extended/{adId}";
            return this.HttpRequest<ProductAdExInfo>(url);
        }

        /// <summary>
        /// Creates one or more product ads. Successfully created product ads will be assigned a unique  adId 
        /// </summary>
        /// <param name="ads">A list of up to 1000 product ads to be created. Required fields for product ad
        /// creation are:  campaignId ,  adGroupId ,  SKU , and state</param>
        /// <returns></returns>
        public List<AdResponse> CreateProductAds(List<ProductAdInfo> ads)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds";
            return this.HttpRequest<List<AdResponse>>(url, JsonConvert.SerializeObject(ads), "POST");
        }

        /// <summary>
        /// Updates one or more product ads. Product ads are identified using their  adIds . 
        /// </summary>
        /// <param name="ads">A list of up to 1000 updates containing  adId s and the mutable fields to be modified.
        /// Mutable fields:  state</param>
        /// <returns></returns>
        public List<AdResponse> UpdateProductAds(List<ProductAdInfo> ads)
        {
            var data = JsonConvert.SerializeObject(
                    ads,
                     Formatting.Indented,
                     new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds";
            return this.HttpRequest<List<AdResponse>>(url, data, "PUT");
        }

        /// <summary>
        /// Sets the product ad status to archived.
        /// </summary>
        /// <param name="adId">The ID of the product ad to be archived.</param>
        /// <returns></returns>
        public AdResponse ArchiveProductAd(string adId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds/{adId}";
            return this.HttpRequest<AdResponse>(url, method: "DELETE");
        }

        /// <summary>
        /// Retrieves a list of product ads with extended fields satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<ProductAdExInfo> ListProductAdsEx(ListProductAdsParameter parameter)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds/extended?{queryData}";
            return this.HttpRequest<List<ProductAdExInfo>>(url);
        }

        /// <summary>
        /// Retrieves a list of product ads satisfying optional criteria.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<ProductAdInfo> ListProductAds(ListProductAdsParameter parameter = null)
        {
            var queryData = string.Empty;
            if (parameter != null)
                queryData = GenQueryData(parameter);

            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/productAds/?{queryData}";
            return this.HttpRequest<List<ProductAdInfo>>(url);
        }

        private static string GenQueryData(ListProductAdsParameter parameter)
        {
            var queryData = new List<string>();
            if (parameter.StartIndex.HasValue)
                queryData.Add($"startIndex={parameter.StartIndex}");
            if (parameter.Count.HasValue)
                queryData.Add($"count={parameter.Count}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignType))
                queryData.Add($"campaignType={parameter.CampaignType}");
            if (!string.IsNullOrWhiteSpace(parameter.Sku))
                queryData.Add($"sku={parameter.Sku}");
            if (!string.IsNullOrWhiteSpace(parameter.Asin))
                queryData.Add($"asin={parameter.Asin}");
            if (!string.IsNullOrWhiteSpace(parameter.AdGroupId))
                queryData.Add($"adGroupId={parameter.AdGroupId}");
            if (!string.IsNullOrWhiteSpace(parameter.StateFilter))
                queryData.Add($"stateFilter={parameter.StateFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.CampaignIdFilter))
                queryData.Add($"campaignIdFilter={parameter.CampaignIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.AdGroupIdFilter))
                queryData.Add($"adGroupIdFilter={parameter.AdGroupIdFilter}");
            if (!string.IsNullOrWhiteSpace(parameter.AdIdFilter))
                queryData.Add($"adIdFilter={parameter.AdIdFilter}");

            return string.Join("&", queryData);
        }
    }
}
