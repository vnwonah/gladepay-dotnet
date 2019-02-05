using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BaseRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
