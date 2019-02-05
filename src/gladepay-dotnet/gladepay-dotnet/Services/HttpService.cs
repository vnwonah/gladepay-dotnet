using gladepay_dotnet.Models;
using gladepay_dotnet.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gladepay_dotnet.Services
{
    public class HttpService
    {
        
        private static readonly Credentials _credentials;

        private static HttpClient _client;

        public HttpService(Credentials credentials)
        {
            if(_client == null)
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri(_credentials.BaseUrl)
                    
                };
                _client.DefaultRequestHeaders.TryAddWithoutValidation("mid", credentials.MerchantId);
                _client.DefaultRequestHeaders.TryAddWithoutValidation("key", credentials.MerchantKey);
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Type", "application/json");
            }
        }

        internal async Task<Response> PutAsync<T>(T request)
        {
            //await _client.PutAsync();
            throw new NotImplementedException();
        }

    }
}
