using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.ResponseModels
{
    public class Account
    {
        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("paymentType")]
        public string Bankcode { get; set; }
    }
}
