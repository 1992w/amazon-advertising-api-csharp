using System.Collections.Generic;
using Amazon.Advertising.API.Models;

namespace Amazon.Advertising.API
{
    public class ProfileClient : BaseClient
    {
        public ProfileClient(string access_token, Marketplace markplace) : base(access_token, markplace)
        {
        }

        public IEnumerable<ProfileInfo> GetProfiles()
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/profiles";
            return this.HttpRequest<IEnumerable<ProfileInfo>>(url);
        }

        public ProfileInfo GetProfile(string profileId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/profiles/{profileId}";
            return this.HttpRequest<ProfileInfo>(url);
        }
    }
}
