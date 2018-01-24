using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class RequestReportParameter
    {
        /// <summary>
        /// The type of campaign for which performance data should be
        /// generated.Must be  sponsoredProducts
        /// </summary>
        [JsonProperty("campaignType")]
        public string CampaignType { get; set; }

        /// <summary>
        /// Optional. Dimension on which to segment the report. If specified, must be query.
        /// </summary>
        [JsonProperty("segment")]
        public string Segment { get; set; }

        /// <summary>
        /// The date for which to retrieve the performance report in YYYYMMDD
        /// format.The time zone is specified by the profile used to request the
        /// report.If this date is today, then the performance report may contain
        /// partial information.Reports are not available for data older than 60
        /// days.For details on data latency, see the Service Guarantees in the
        /// Developer Notes.
        /// </summary>
        [JsonProperty("reportDate")]
        public string ReportDate { get; set; }

        /// <summary>
        /// A comma-separated list of the metrics to be included in the report. See
        /// Report Metrics in the Developer Notes for a complete list of supported
        /// metrics.
                /// </summary>
        [JsonProperty("metrics")]
        public string Metrics { get; set; }
    }
}
