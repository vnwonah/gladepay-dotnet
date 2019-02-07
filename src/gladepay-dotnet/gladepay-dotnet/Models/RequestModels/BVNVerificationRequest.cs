using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BVNVerificationRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "bvn";

        [JsonProperty("bvn")]
        public string BVN { get; set; }
    }
}
