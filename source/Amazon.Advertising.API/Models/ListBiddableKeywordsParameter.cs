namespace Amazon.Advertising.API.Models
{
    public class ListBiddableKeywordsParameter
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
        /// Optional. Restricts results to keywords belonging to campaigns of the
        /// specified type.Must be sponsoredProducts
        /// </summary>
        public string CampaignType { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords with match types within the
        /// specified comma-separated list.Valid values are broad, phrase, exact
        /// </summary>
        public string MatchTypeFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords with the specified  keywordText .
        /// </summary>
        public string KeywordText { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords with state within the specified
        /// comma-separated list.Must be one of:  enabled , paused , or archived .
        /// Default behavior is to include all.
        /// </summary>
        public string StateFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords within campaigns specified in
        /// comma-separated list.
        /// </summary>
        public string CampaignIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords within ad groups specified in
        /// comma-separated list.
        /// </summary>
        public string AdGroupIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords with the specified keyword Id
        /// specified in comma-separated list.
        /// </summary>
        public string KeywordIdFilter { get; set; }
    }
}
