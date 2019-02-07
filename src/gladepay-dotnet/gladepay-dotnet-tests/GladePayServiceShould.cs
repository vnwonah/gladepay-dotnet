using gladepay_dotnet.Enums;
using gladepay_dotnet.Models;
using gladepay_dotnet.Models.RequestModels;
using gladepay_dotnet.Models.ResponseModels;
using gladepay_dotnet.Services;
using System;
using System.Net;
using Xunit;

namespace gladepay_dotnet_tests
{
    public class GladePayServiceShould
    {
        private GladePayService _gladepayService;

        public GladePayServiceShould()
        {
            _gladepayService = new GladePayService(new Credential
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
            var res = await _gladepayService.PutAsync<CardChargeRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.Accepted);
        }

        [Fact]
        public async void ValidateChargeRequest()
        {

            //Arrange
            var res = new Response();

            var req1 = new CardChargeRequest
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
            res = await _gladepayService.PutAsync<CardChargeRequest>(req1);

            var req = new CardChargeValidationRequest
            {
                OTP = "123456",
                TxnRef = res.Data["txnRef"].ToString()

            };

            res = await _gladepayService.PutAsync<CardChargeValidationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async void InitiateRecurringCardChargeRequest()
        {
            //Arrange
            var req = new RecurringCardChargeRequest
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
                Currency = "NGN",
                Recurrent = new Recurrent
                {
                    ChargeFrequency = Frequency.Daily,
                    ChargePeriod = "00"
                }
            };

            //Act
            var res = await _gladepayService.PutAsync<RecurringCardChargeRequest>(req);
        }
    }
}
