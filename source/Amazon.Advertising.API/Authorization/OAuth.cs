using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Amazon.Advertising.API.Authorization
{
    public class OAuth
    {
        /// <summary>
        /// Authorization Request
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string AuthorizationRequest(AuthorizationRequestParameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.RedirectUrl))
                throw new ArgumentNullException("parameter.RedirectUrl", "RedirectUrl is required");
            if (string.IsNullOrWhiteSpace(parameter.ClientId))
                throw new ArgumentNullException("parameter.ClientId", "ClientId is required");
            if (string.IsNullOrWhiteSpace(parameter.Scope))
                throw new ArgumentNullException("parameter.Scode", "Scode is required");
            if (string.IsNullOrWhiteSpace(parameter.ResponseType))
                throw new ArgumentNullException("parameter.ResponseType", "ResponseType is required");

            var url = "https://www.amazon.com/ap/oa?client_id=" + parameter.ClientId
+ "&scope=" + Uri.EscapeDataString(parameter.Scope)
+ "&response_type=" + parameter.ResponseType
+ "&state=" + parameter.State
+ "&redirect_uri=" + Uri.EscapeDataString(parameter.RedirectUrl);
            return url;
        }

        /// <summary>
        /// AccessToken Request
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AccessTokenResponse AccessTokenRequest(AccessTokenRequestParameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.ClientId))
                throw new ArgumentNullException("ClientId is required");
            if (string.IsNullOrWhiteSpace(parameter.ClientSecret))
                throw new ArgumentNullException("ClientSecret is required");
            if (string.IsNullOrWhiteSpace(parameter.Code))
                throw new ArgumentNullException("Code is required");
            if (string.IsNullOrWhiteSpace(parameter.GrantType))
                throw new ArgumentNullException("GrantType is required");
            if (string.IsNullOrWhiteSpace(parameter.RedirectUrl))
                throw new ArgumentNullException("RedirectUrl is required");

            var url = "https://api.amazon.com/auth/o2/token";
            var data = string.Format("grant_type={0}&code={1}&redirect_uri={2}&client_id={3}&client_secret={4}",
                parameter.GrantType,
                parameter.Code,
                parameter.RedirectUrl,
                parameter.ClientId,
                parameter.ClientSecret);

            try
            {
                var response = PostWebRequest(url, data);
                return GenAccessToken(response);
            }
            catch (Exception ex)
            {
                return new AccessTokenResponse() { Error = "request_error", ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public AccessTokenResponse RefreshToken(RefreshTokenParameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.RefreshToken))
                throw new ArgumentNullException("RefreshToken is required");
            if (string.IsNullOrWhiteSpace(parameter.GrantType))
                throw new ArgumentNullException("GrantType is required");
            if (string.IsNullOrWhiteSpace(parameter.ClientId))
                throw new ArgumentNullException("ClientId is required");
            if (string.IsNullOrWhiteSpace(parameter.SecretId))
                throw new ArgumentNullException("SecretId is required");

            var url = "https://api.amazon.com/auth/o2/token";
            var data = $"grant_type={parameter.GrantType}&refresh_token={parameter.RefreshToken}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var postData = Encoding.UTF8.GetBytes(data);
            var authorization = $"{parameter.ClientId}:{parameter.SecretId}";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new UTF8Encoding().GetBytes(authorization)));
            request.ContentLength = postData.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(postData, 0, postData.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return GenAccessToken(responseString);
            }
            catch (Exception e)
            {
                return new AccessTokenResponse() { Error = "request_error", ErrorDescription = e.Message };
            }
        }


        public bool VerifyAccessToken(string access_token, string client_id)
        {
            if (string.IsNullOrWhiteSpace(access_token))
                throw new ArgumentNullException("access_token is required");

            var url = "https://api.amazon.com/auth/O2/tokeninfo?access_token=" + access_token;
            var response = HttpGet(url);
            if (string.IsNullOrWhiteSpace(response))
                return false;

            var token_info = JsonConvert.DeserializeObject<VerifyAccessTokenResponse>(response);
            if (string.IsNullOrWhiteSpace(token_info.Aud))
                return false;

            return token_info.Aud == client_id;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CustomerProfileResponse GetCustomerProfile(string access_token)
        {
            if (string.IsNullOrWhiteSpace(access_token))
                throw new ArgumentException("Invalid Parameter: access_token");

            var url = "https://api.amazon.com/user/profile?access_token=" + access_token;
            try
            {
                var response = HttpGet(url);
                if (string.IsNullOrWhiteSpace(response))
                    return null;
                return JsonConvert.DeserializeObject<CustomerProfileResponse>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Post提交数据
        /// </summary>
        /// <param name="postUrl">URL</param>
        /// <param name="paramData">参数</param>
        /// <returns></returns>
        private string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;
            byte[] byteArray = Encoding.UTF8.GetBytes(paramData);
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();

            return ret;
        }

        private string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        private static AccessTokenResponse GenAccessToken(string response_str)
        {
            if (string.IsNullOrWhiteSpace(response_str))
                return new AccessTokenResponse() { Error = "request_error", ErrorDescription = "response is empty" };

            return JsonConvert.DeserializeObject<AccessTokenResponse>(response_str);
        }
    }
}
