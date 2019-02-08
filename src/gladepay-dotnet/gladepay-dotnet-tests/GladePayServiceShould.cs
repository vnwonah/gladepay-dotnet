using gladepay_dotnet.Enums;
using gladepay_dotnet.Models;
using gladepay_dotnet.Models.RequestModels;
using gladepay_dotnet.Models.ResponseModels;
using gladepay_dotnet.Services;
using System;
using System.Diagnostics;
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
        public async void InitiateCardChargeRequest()
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
            Debug.WriteLine(res.Data);

            var req = new CardChargeValidationRequest
            {
                OTP = "123456",
                TxnRef = res.Data["txnRef"].ToString()

            };

            res = await _gladepayService.PutAsync<CardChargeValidationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);

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

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async void GetListOfBanks()
        {
            //Arrange
            var req = new BankListRequest();

            //Act
            var res = await _gladepayService.PutAsync<BankListRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void GetChargeableBankList()
        {
            //Arrange 
            var req = new ChargeableBankListRequest();

            //Act
            var res = await _gladepayService.PutAsync<ChargeableBankListRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);

        }

        [Fact]
        public async void VerifyAccountDetails()
        {
            //Arrange
            var req = new AccountDetailsVerificationRequest
            {
                AccountNumber = "0040000009",
                BankCode = "058"
            };

            //Act
            var res = await _gladepayService.PutAsync<AccountDetailsVerificationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void VerifyBVNDetails()
        {
            //Arrange
            var req = new BVNVerificationRequest
            {
                BVN = "12345678901"
            };

            //Act
            var res = await _gladepayService.PutAsync<BVNVerificationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void GetListofBills()
        {
            //Arrange
            var req = new BillsListRequest();

            //Act
            var res = await _gladepayService.PutAsync<BillsListRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void ValidateCustomerInformationForBill()
        {
            //Arrange
            var req = new CustomerBillInformationVerificationRequest
            {
                PayCode = "lAApm6OBmRmp3cQ",
                Reference = "0000000001"
            };

            //Act
            var res = await _gladepayService.PutAsync<CustomerBillInformationVerificationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);

        }

        [Fact]
        public async void MakeBillPayment()
        {
            var req = new BillPaymentRequest
            {
                Paycode = "lAApm6OBmRmp3cQ",
                Reference = "0000000001",
                Amount = "100",
                OrderReference = "abcd"
            };

            var res = await _gladepayService.PutAsync<BillPaymentRequest>(req);


            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void VerifyBillPayment()
        {
            //Arrange
            var req = new BillPaymentVerificationRequest
            {
                TransactionReference = "GP|BP|987555815|20190115N"
            };


            //Act
            var res = await _gladepayService.PutAsync<BillPaymentVerificationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);
        }

        /// <summary>
        /// This service is not available on the test API. 
        /// </summary>
        [Fact]
        public async void ChargeBankAccount()
        {
            //Arrange
            var req = new AccountChargeRequest
            {
                User = new User
                {
                    FirstName = "Vincent",
                    LastName = "Nwonah",
                    Email = "vnwonah@outlook.com",
                    IP = "192.168.33.10",
                    FingerPrint = "ddsdschhdghgshghdgshghcx"
                },
                Account = new Account
                {
                    AccountNumber = "0226197826",
                    BankCode = "058"
                },
                Amount = "100"
            };

            //Act 
            var res = await _gladepayService.PutAsync<AccountChargeRequest>(req);

            //Assert
            Assert.True(res.Data["message"].ToString() == "Error: This method is not avaialble in test mode");
            Debug.WriteLine(res.Data);
        }

        [Fact]
        public async void ValidateBankAccountCharge()
        {
            //Arrange
            var req = new AccountChargeValidationRequest
            {
                TransactionReference = "GP547925318M",
                OTP = "123456"
            };

            //Act 
            var res = await _gladepayService.PutAsync<AccountChargeValidationRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            

        }

        [Fact]
        public async void InitiateMoneyTransferRequest()
        {
            //Arrange
            var req = new MoneyTransferRequest
            {
                Amount = "100",
                BankCode = "058",
                AccountNumber = "0040000008",
                SenderName = "John Doe",
                Narration = "Upkeep",
                OrderReference = "TX00001"
            };

            //Assert
            var res = await _gladepayService.PutAsync<MoneyTransferRequest>(req);

            //Assert
            Assert.True(res.StatusCode == HttpStatusCode.OK);
            Debug.WriteLine(res.Data);

        }
    }
}
