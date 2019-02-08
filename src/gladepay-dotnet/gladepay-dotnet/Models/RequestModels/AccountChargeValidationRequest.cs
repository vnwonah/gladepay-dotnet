using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class AccountChargeValidationRequest
    {
        [JsonProperty("action")]
        public const string Action = "validate";

        [JsonProperty("validate")]
        public const string Validate = "account";

        [JsonProperty("txnRef")]
        public string TransactionReference { get; set; }

        [JsonProperty("otp")]
        public string OTP { get; set; }
    }
}
