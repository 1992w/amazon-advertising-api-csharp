using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public class SnapshotClient : BaseClient
    {
        public SnapshotClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// Request a snapshot report for all entities of a single type
        /// </summary>
        /// <param name="recordType">The type of entity for which the snapshot should be generated. This
        /// must be one of:  campaigns ,  adGroups ,  keywords ,  negativeKeywords , campaignNegativeKeywords , 
        /// or productAds</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public SnapshotResponse RequestSnapshot(string recordType, RequestSnaphotParameter parameter)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/{recordType}/snapshot";
            return this.HttpRequest<SnapshotResponse>(url, JsonConvert.SerializeObject(parameter), "POST");
        }
    }
}
