using System;

namespace Amazon.Advertising.API
{
    public class APIEndpoint
    {
        private static string SandBoxUrl = "https://advertising-api-test.amazon.com";
        private static string NorthAmericaUrl = "https://advertising-api.amazon.com";
        private static string EuropeUrl = "https://advertising-api-eu.amazon.com";

        public static string GetUrl(Marketplace markplace)
        {
            switch (markplace)
            {
                case Marketplace.SandBox:
                    return SandBoxUrl;
                case Marketplace.US:
                case Marketplace.CA:
                case Marketplace.MX:
                    return NorthAmericaUrl;
                case Marketplace.UK:
                case Marketplace.FR:
                case Marketplace.IT:
                case Marketplace.ES:
                case Marketplace.DE:
                case Marketplace.IN:
                    return EuropeUrl;
                default:
                    throw new ArgumentException("不支持的marktplace");
            }
        }
    }
}
