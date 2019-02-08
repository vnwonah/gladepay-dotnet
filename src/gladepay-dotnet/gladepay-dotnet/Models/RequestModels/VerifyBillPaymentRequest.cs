using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class VerifyBillPaymentRequest
    {
        [JsonProperty("action")]
        public const string Action = "verify";

        [JsonProperty("txnRef")]
        public string TransactionReference { get; set; }
    }
}
