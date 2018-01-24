using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Advertising.API
{
    public abstract class BaseClient
    {
        public Marketplace Marketplace { get; set; }

        public string ProfileId { get; set; }

        public virtual string ApiVersion
        {
            get
            {
                return "v1";
            }
        }

        public string AccessToken { get; set; }

        public BaseClient(string access_token, Marketplace marketplace)
            : this(access_token, marketplace, string.Empty)
        {
        }

        public BaseClient(string access_token, Marketplace marketplace, string profileId)
        {
            if (string.IsNullOrWhiteSpace(access_token))
                throw new ArgumentNullException("access_token is empty");

            this.AccessToken = access_token;
            this.Marketplace = marketplace;
            this.ProfileId = profileId;
        }

        protected T HttpRequest<T>(string url, string data = null, string method = "GET")
        {
            NameValueCollection headers = new NameValueCollection();
            if (string.IsNullOrWhiteSpace(this.ProfileId) == false)
                headers.Add("Amazon-Advertising-API-Scope", this.ProfileId);

            return HttpRequest<T>(new RequestParameter()
            {
                Url = url,
                Data = data,
                Method = method,
                Headers = headers
            });
        }

        protected T HttpRequest<T>(RequestParameter parameter)
        {
            return JsonConvert.DeserializeObject<T>(this.HttpRequest(parameter));
        }
        
        protected string HttpRequest(RequestParameter parameter)
        {
            parameter.Check();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(parameter.Url);
            request.Method = parameter.Method;
            request.Headers.Add("Authorization", $"Bearer {this.AccessToken}");
            request.ContentType = parameter.ContentType ?? "application/json";
            if (parameter.Headers != null)
            {
                foreach (var key in parameter.Headers.AllKeys)
                {
                    request.Headers.Add(key, parameter.Headers[key]);
                }
            }

            if (!string.IsNullOrWhiteSpace(parameter.Data))
            {
                var postData = Encoding.UTF8.GetBytes(parameter.Data);
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(postData, 0, postData.Length);
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var myResponseStream = response.GetResponseStream())
            {
                using (var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
                {
                    return myStreamReader.ReadToEnd();
                }
            }
        }
    }

    public class RequestParameter
    {
        public string Method { get; set; } = "GET";

        public string Url { get; set; }

        public string Data { get; set; }

        public NameValueCollection Headers { get; set; }

        public string ContentType { get; set; } = "application/json";

        public void Check()
        {
            if (string.IsNullOrWhiteSpace(Method))
                throw new ArgumentException("Method is required");

            if (string.IsNullOrWhiteSpace(Url))
                throw new ArgumentException("Url is required");
        }
    }
}
