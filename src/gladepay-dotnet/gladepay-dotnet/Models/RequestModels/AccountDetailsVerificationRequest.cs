using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class AccountDetailsVerificationRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "accountname";

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("bankcode")]
        public string BankCode { get; set; }
    }
}
