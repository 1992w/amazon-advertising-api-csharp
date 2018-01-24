using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using Amazon.Advertising.API.Models;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    /// <summary>
    /// Used to request and retrieve performance reports. 
    /// </summary>
    public class ReportClient : BaseClient
    {
        public ReportClient(string access_token, Marketplace marketplace, string profileId)
            : base(access_token, marketplace, profileId)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordType">The type of entity for which the report should be generated. This must
        /// be one of:  campaigns ,  adGroups ,  keywords , or productAds</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public RequestReportResponse RequestReport(string recordType, RequestReportParameter parameter)
        {
            var data = JsonConvert.SerializeObject(
                    parameter,
                    Formatting.Indented,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/{recordType}/report";
            return this.HttpRequest<RequestReportResponse>(url, data, "POST");
        }

        /// <summary>
        /// Retrieve a previously requested report
        /// </summary>
        /// <param name="reportId">The ID of the requested report</param>
        /// <returns></returns>
        public RequestReportResponse GetReport(string reportId)
        {
            var url = $"{APIEndpoint.GetUrl(this.Marketplace)}/{this.ApiVersion}/reports/{reportId}";
            return this.HttpRequest<RequestReportResponse>(url);
        }

        /// <summary>
        /// download report
        /// </summary>
        /// <param name="url">report uri</param>
        /// <returns></returns>
        public string DownReport(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", $"Bearer {this.AccessToken}");
            request.Headers.Add("Amazon-Advertising-API-Scope", this.ProfileId);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var myResponseStream = response.GetResponseStream())
            {
                using (GZipStream gzip = new GZipStream(myResponseStream, CompressionMode.Decompress))
                {
                    using (var myStreamReader = new StreamReader(gzip, Encoding.GetEncoding("utf-8")))
                    {
                        return myStreamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
