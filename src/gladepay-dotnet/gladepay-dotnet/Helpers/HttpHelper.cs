using gladepay_dotnet.Enums;
using gladepay_dotnet.Models.RequestModels;
using gladepay_dotnet.Models.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gladepay_dotnet.Helpers
{
    internal static class HttpHelper
    {
        internal static string Serialize<T>(T @object)
        {
            return JsonConvert.SerializeObject(@object);
        }

        internal static async Task<Response> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var content = JObject.Parse(await response.Content.ReadAsStringAsync());

            var responseObject = new Response
            {
                StatusCode = GetResponseCode(content["status"].ToString()),
                RequestParameters = JObject.Parse(Serialize(response.RequestMessage)),
                Headers = JArray.Parse(Serialize(response.Headers))
            };
            
            content.Remove("status");
            responseObject.Data = content;
            return responseObject;
        }

        internal static HttpStatusCode GetResponseCode(string status)
        {
            switch (status)
            {
                case "202":
                    return HttpStatusCode.Accepted;
                default:
                    return HttpStatusCode.OK;
            }
        }

        internal static string GetEndpoint(Endpoint endPoint)
        {
            return endPoint.ToString();
        }
    }
}
