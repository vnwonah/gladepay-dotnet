using gladepay_dotnet.Enums;
using gladepay_dotnet.Models;
using gladepay_dotnet.Models.RequestModels;
using gladepay_dotnet.Services;
using System;
using System.Net;
using Xunit;

namespace gladepay_dotnet_tests
{
    public class HttpServiceShould
    {
        private HttpService _httpService;

        public HttpServiceShould()
        {
            _httpService = new HttpService(new Credential
            {
                BaseUrl = "https://demo.api.gladepay.com/?method=",
                MerchantId = "GP0000001",
                MerchantKey = "123456789"
            });
        }
        [Fact]
        public async void SendPutRequest()
        {
            //Arrange
            var req = new CardChargeRequest
            {
                Action = "initiate",
                User = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "hello@example.com",
                    IP = "192.168.33.10",
                    FingerPrint = "cccvxbxbxb"
                },
                Card = new Card
                {
                    CardNumber = "5438898014560229",
                    ExpiryMonth = "09",
                    ExpiryYear = "19",
                    CCV = "789",
                    Pin = "3310"
                },
                Amount = "10000",
                Country = "NG",
                Currency = "NGN"         
            };

            //Act
            var res = await _httpService.PutAsync<CardChargeRequest>(Endpoint.payment, req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.Accepted);
        }
    }
}
