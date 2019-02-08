using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class MoneyTransferRequest
    {
        [JsonProperty("action")]
        public const string Action = "transfer";

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("bankcode")]
        public string BankCode { get; set; }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("orderRef")]
        public string OrderReference { get; set; }

    }
}
