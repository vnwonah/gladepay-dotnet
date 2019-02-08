using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class ValidateCustomerBillInformationRequest
    {
        [JsonProperty("action")]
        public const string Action = "resolve";

        /// <summary>
        /// This is the paycode for the biller pay item you want to resolve for
        /// </summary>
        [JsonProperty("paycode")]
        public string PayCode { get; set; }

        /// <summary>
        /// The reference can be the smart card no. for Cable payment or phone number for airtime topup
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
       

    }
}
