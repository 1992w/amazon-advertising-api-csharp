namespace Amazon.Advertising.API.Models
{
    public class ListProductAdsParameter
    {
        /// <summary>
        /// Optional. 0-indexed record offset for the result set. Defaults to 0.
        /// </summary>
        public int? StartIndex { get; set; }

        /// <summary>
        /// Optional. Number of records to include in the paged response. Defaults
        /// to max page size.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Optional. Restricts results to ads belonging to campaigns of the specified
        /// type.Must be  sponsoredProducts
        /// </summary>
        public string CampaignType { get; set; }

        /// <summary>
        /// Optional. Restricts results to product ads with the specified  sku .
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Optional. Restricts results to product ads with the specified  asin 
        /// </summary>
        public string Asin { get; set; }

        /// <summary>
        /// Optional. Restricts results to product ads with the specified  adGroupId 
        /// </summary>
        public string AdGroupId { get; set; }

        /// <summary>
        /// Optional. Restricts results to ads with state within the specified comma-
        /// separated list.Must be one of:  enabled , paused , archived.Default
        /// behavior is to include all.
        /// </summary>
        public string StateFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to ads within campaigns specified in comma-
        /// separated list.
        /// </summary>
        public string CampaignIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to ads within ad groups specified in comma-
        /// separated list.
        /// </summary>
        public string AdGroupIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to ads with the specified product ad Id
        /// specified in comma-separated list.
        /// </summary>
        public string AdIdFilter { get; set; }
    }
}
