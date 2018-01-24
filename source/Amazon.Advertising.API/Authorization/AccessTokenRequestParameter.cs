namespace Amazon.Advertising.API.Authorization
{
    public class AccessTokenRequestParameter
    {
        /// <summary>
        /// 目前只能传authorization_code
        /// </summary>
        public string GrantType { get; set; } = "authorization_code";

        /// <summary>
        /// 从authorization request获取到的code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 传递跟Authorization Request一样的重定向url
        /// </summary>
        public string RedirectUrl { get; set; }
        
        /// <summary>
        /// Application Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Application Client Secret
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
