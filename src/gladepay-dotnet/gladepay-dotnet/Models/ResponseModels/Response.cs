using gladepay_dotnet.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Models.ResponseModels
{
    internal class Response
    {
        internal ResponseCode Status { get; set; }

        internal string Message { get; set; }

        internal JObject Data { get; set; }
    }
}
