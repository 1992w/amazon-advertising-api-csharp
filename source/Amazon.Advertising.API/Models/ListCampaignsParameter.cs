using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Advertising.API.Models
{
    public class ListCampaignsParameter
    {
        /// <summary>
        /// Optional. 0-indexed record offset for the result set. Defaults to 0.
        /// </summary>
        public int? StartIindex { get; set; } = 0;

        /// <summary>
        /// Optional. Restricts results to campaigns of a single campaign type. Must
        /// be sponsoredProducts
        /// </summary>
        public string CampaignType { get; set; }

        /// <summary>
        /// Optional. Number of records to include in the paged response. Defaults
        /// to max page size.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Optional. Restricts results to campaigns with state within the specified
        /// comma-separated list.Must be one of enabled, paused, archived.Default
        /// behavior is to include all.
        /// </summary>
        public string StateFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to campaigns with the specified name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Optional. Restricts results to campaigns specified in comma-separatedlist.
        /// </summary>
        public string CampaignIdFilter { get; set; }
    }
}
