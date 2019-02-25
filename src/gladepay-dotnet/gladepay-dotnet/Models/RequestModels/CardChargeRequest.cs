using gladepay_dotnet.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.RequestModels
{
    public class CardChargeRequest
    {
        [JsonProperty("action")]
        public readonly string Action = "initiate";

        [JsonProperty("paymentType")]
        public readonly string PaymentType = "card";

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
