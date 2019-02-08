using Newtonsoft.Json;
using System.Collections.Generic;

namespace gladepay_dotnet.Models.RequestModels
{
    /// <summary>
    /// This request type only works when you're using live credentials
    /// </summary>
    public class BulkMoneyTransferRequest
    {
        [JsonProperty("action")]
        public const string Action = "transfer";

        [JsonProperty("type")]
        public const string Type = "bulk";

        [JsonProperty("data")]
        public List<TransferItem> TransferItems { get; set; }
    }

    public class TransferItem
    {
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
