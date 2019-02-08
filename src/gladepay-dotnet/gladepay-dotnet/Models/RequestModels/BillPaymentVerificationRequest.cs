using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BillPaymentVerificationRequest
    {
        [JsonProperty("action")]
        public const string Action = "verify";

        [JsonProperty("txnRef")]
        public string TransactionReference { get; set; }
    }
}
