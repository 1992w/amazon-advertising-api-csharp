using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Advertising.API.Models
{
    public class ListAdGroupsParameter
    {
        /// <summary>
        /// Optional. 0-indexed record offset for the result set. Defaults to 0.
        /// </summary>
        public int? StartIndex { get; set; }


        /// <summary>
        /// Optional. Number of records to include in the paged response. Defaults to max page size.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Optional. Restricts results to ad groups belonging to campaigns of the specified type. Must be 
        ///  sponsoredProducts.
        /// </summary>
        public string CampaignType { get; set; }

        /// <summary>
        /// Optional. Restricts results to ad groups within campaigns specified in
        /// comma-separated list.
        /// </summary>
        public string CampaignIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to ad groups specified in comma-separated list.
        /// </summary>
        public string AdGroupIdFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to keywords with state within the specified
        /// comma-separated list.Must be one of enabled, paused , or archived .
        /// Default behavior is to include all.
        /// </summary>
        public string StateFilter { get; set; }

        /// <summary>
        /// Optional. Restricts results to ad groups with the specified name.
        /// </summary>
        public string Name { get; set; }
    }
}
