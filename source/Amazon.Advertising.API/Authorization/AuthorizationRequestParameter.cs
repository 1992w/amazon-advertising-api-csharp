namespace Amazon.Advertising.API.Authorization
{
    public class AuthorizationRequestParameter
    {
        public string ClientId { get; set; }

        /// <summary>
        /// 重定向地址，必须是https
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// 防止跨站请求伪造，重定向后会返回该值
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Scope { get; set; } = "profile";

        /// <summary>
        /// 
        /// </summary>
        public string ResponseType { get; set; } = "token";
    }
}
