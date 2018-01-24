using Newtonsoft.Json;

namespace Amazon.Advertising.API.Models
{
    public class ProfileInfo
    {
        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("dailyBudget")]
        public long? DailyBudget { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("accountInfo")]
        public AccountInfo AccountInfo { get; set; }
    }

    public class AccountInfo
    {
        [JsonProperty("marketplaceStringId")]
        public string MarketplaceStringId { get; set; }

        [JsonProperty("sellerStringId")]
        public string SellerStringId { get; set; }
    }
}
