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
    internal static class GladepayServiceHelper
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
                RequestParameters = JObject.Parse(Serialize(response.RequestMessage)),
                Headers = JArray.Parse(Serialize(response.Headers))
            };

            try
            {
                responseObject.StatusCode = GetResponseCode(content["status"].ToString());
            }
            catch (Exception e)
            {
                if (content.ContainsKey("214"))
                {
                    responseObject.StatusCode = HttpStatusCode.OK;
                }
            }

            content.Remove("status");
            responseObject.Data = content;
            return responseObject;
        }

        internal static HttpStatusCode GetResponseCode(string status)
        {
            switch (status)
            {
                case "200":
                    return HttpStatusCode.OK;
                case "202":
                    return HttpStatusCode.Accepted;
                case "success":
                    return HttpStatusCode.OK;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }

        internal static string GetEndpoint<T>(T requestObject) where T : new()
        {
            if (requestObject.GetType() == typeof(CardChargeRequest))
                return GetEndpoint(Endpoint.payment);
            else if (requestObject.GetType() == typeof(CardChargeValidationRequest))
                return GetEndpoint(Endpoint.payment);
            else if (requestObject.GetType() == typeof(RecurringCardChargeRequest))
                return GetEndpoint(Endpoint.payment);
            else if (requestObject.GetType() == typeof(BankListRequest))
                return GetEndpoint(Endpoint.resources);
            else if (requestObject.GetType() == typeof(ChargeableBankListRequest))
                return GetEndpoint(Endpoint.resources);
            else if (requestObject.GetType() == typeof(AccountDetailsVerificationRequest))
                return GetEndpoint(Endpoint.resources);
            else if (requestObject.GetType() == typeof(BVNVerificationRequest))
                return GetEndpoint(Endpoint.resources);
            return GetEndpoint(Endpoint.disburse);
        }

        internal static string GetEndpoint(Endpoint endPoint)
        {
            return endPoint.ToString();
        }
    }
}
