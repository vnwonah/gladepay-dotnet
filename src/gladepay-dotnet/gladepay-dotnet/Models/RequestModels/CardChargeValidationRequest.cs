using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.RequestModels
{
    public class CardChargeValidationRequest
    {
        [JsonProperty("action")]
        public const string Action = "validate";

        [JsonProperty("txnRef")]
        public string TxnRef { get; set; }

        [JsonProperty("otp")]
        public string OTP { get; set; }


    }
}
