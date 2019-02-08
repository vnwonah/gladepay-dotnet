using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class TransactionVerificationRequest
    {
        [JsonProperty("action")]
        public const string Action = "verify";

        [JsonProperty("txnRef")]
        public string TransactionReference { get; set; }
    }
}
