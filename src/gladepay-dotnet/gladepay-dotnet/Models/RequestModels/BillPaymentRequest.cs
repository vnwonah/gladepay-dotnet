using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BillPaymentRequest
    {
        [JsonProperty("action")]
        public const string Action = "pay";

        [JsonProperty("paycode")]
        public string Paycode { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("orderRef")]
        public string OrderReference { get; set; }
    }
}
