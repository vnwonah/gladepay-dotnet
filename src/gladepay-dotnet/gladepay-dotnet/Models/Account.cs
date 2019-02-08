using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models
{
    public class Account
    {
        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("bankcode")]
        public string BankCode { get; set; }
    }
}
