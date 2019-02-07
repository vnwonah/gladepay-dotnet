using gladepay_dotnet.Models.ResponseModels;
using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class AccountChargeRequest : BaseRequest
    {
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; } = "account";

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

    }
}
