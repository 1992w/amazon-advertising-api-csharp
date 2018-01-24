using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class SnapshotResponse
    {
        /// <summary>
        /// The ID of the for the snapshot that was requested.
        /// </summary>
        [JsonProperty("snapshotId")]
        public string SnapshotId { get; set; }

        /// <summary>
        /// The record type of the report. It can be campaign, adGroups, productAds,
        /// keywords, negativeKeywords or campaignNegativeKeywords.
        /// </summary>
        [JsonProperty("recordType")]
        public string RecordType { get; set; }

        /// <summary>
        /// The status of the generation of the snapshot, it can be IN_PROGRESS, SUCCESS or FAILURE.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Description of the status.
        /// </summary>
        [JsonProperty("statusDetails")]
        public string StatusDetails { get; set; }

        /// <summary>
        /// The URI for the snapshot. It’s only available if status is SUCCESS.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// The size of the snapshot file in bytes. It’s only available if status is SUCCESS.
        /// </summary>
        [JsonProperty("fileSize")]
        public long? FileSize { get; set; }

        /// <summary>
        /// The epoch time for expiration of the snapshot file. It’s only available if status is SUCCESS.
        /// </summary>
        [JsonProperty("expiration")]
        public long? Expiration { get; set; }
    }
}
