using gladepay_dotnet.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace gladepay_dotnet.Models.ResponseModels
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }

        public JObject Data { get; set; }

        public JArray Headers { get; set; }

        public JObject RequestParameters { get; set; }


    }
}
