using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BankListRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "banks";
    }
}
