using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class RequestReportResponse
    {
        /// <summary>
        /// The ID of the report that was requested.
        /// </summary>
        [JsonProperty("reportId")]
        public string ReportId { get; set; }

        /// <summary>
        /// The record type of the report. It can be campaigns, adGroups, productAds or keywords.
        /// </summary>
        [JsonProperty("recordType")]
        public string RecordType { get; set; }

        /// <summary>
        /// The status of the generation of the report, it can be IN_PROGRESS, SUCCESS or FAILURE.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Description of the status.
        /// </summary>
        [JsonProperty("statusDetails")]
        public string StatusDetails { get; set; }

        /// <summary>
        /// The URI from the API service from which a redirect to the report can be found.
        /// It’s only available if status is SUCCESS.
        /// </summary>
        [JsonProperty("Location")]
        public string Location { get; set; }

        /// <summary>
        /// The size of the report file in bytes. It’s only available if status is SUCCESS.
        /// </summary>
        [JsonProperty("fileSize")]
        public long? FileSize { get; set; }
    }
}
