using gladepay_dotnet.Enums;
using gladepay_dotnet.Helpers;
using gladepay_dotnet.Models;
using gladepay_dotnet.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gladepay_dotnet.Services
{
    public class GladePayService
    {
        
        private static Credential _credential;

        private static HttpClient _client;

        public GladePayService(Credential credential)
        {
            if(_client == null)
            {
                _credential = credential;
                _client = new HttpClient
                {
                    BaseAddress = new Uri(_credential.BaseUrl)
                    
                };
                _client.DefaultRequestHeaders.TryAddWithoutValidation("mid", credential.MerchantId);
                _client.DefaultRequestHeaders.TryAddWithoutValidation("key", credential.MerchantKey);
                _client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            }
        }

        public async Task<Response> PutAsync<T>(T requestObject) where T : new()
        {
            var content = CreateContent(GladepayServiceHelper.Serialize(requestObject));


            var response = await _client.PutAsync(GladepayServiceHelper.GetEndpoint(requestObject), content);

            return await GladepayServiceHelper.DeserializeResponseAsync(response);
        }

        private StringContent CreateContent(string contentString)
        {
            return new StringContent(contentString, Encoding.UTF8, "application/json");
        }

    }
}
