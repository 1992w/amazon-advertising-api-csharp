namespace Amazon.Advertising.API.Models
{
    public class getAdGroupSuggestedKeywordsExParameter
    {
        /// <summary>
        /// Maximum expected number of suggested keywords. Default is 100, maximum is 1000
        /// </summary>
        public int? MaxNumSuggestions { get; set; }

        /// <summary>
        /// Valid values are yes and no. Default value is no. If yes, any suggested
        /// keywords can contain the extra bid field, where bid will be populated by
        /// calculated suggested bid
        /// </summary>
        /// <remarks>
        /// The bid field will be missing if there are no suggested bids for the keyword
        /// </remarks>
        public string SuggestBids { get; set; }

        /// <summary>
        /// Ad state filter (values are comma separated) to filter out the ads to get
        /// suggested keywords for their ASINs.Valid values are:  enabled , paused ,
        /// and archived . Default values are enabled and paused
        /// </summary>
        public string AdStateFilter { get; set; }
    }
}
