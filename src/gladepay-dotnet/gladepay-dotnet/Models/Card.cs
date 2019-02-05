using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models
{
    public class Card
    {
        [JsonProperty("card_no")]
        public string CardNumber { get; set; }

        [JsonProperty("expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public string ExpiryYear { get; set; }

        [JsonProperty("cvv")]
        public string CCV { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}
