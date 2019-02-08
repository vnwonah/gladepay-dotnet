using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class AccountChargeRequest
    {
        [JsonProperty("action")]
        public const string Action = "charge";

        [JsonProperty("paymentType")]
        public const string PaymentType = "account";

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

    }
}
