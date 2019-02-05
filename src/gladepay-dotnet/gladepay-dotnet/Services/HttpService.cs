using gladepay_dotnet.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace gladepay_dotnet.Services
{
    public class HttpService
    {
        private static HttpClient _client;

        public HttpService(string baseUrl)
        {
            if(_client == null)
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
            }
        }

        internal Response Put<T>(T request)
        {
            throw new NotImplementedException();
        }

    }
}
