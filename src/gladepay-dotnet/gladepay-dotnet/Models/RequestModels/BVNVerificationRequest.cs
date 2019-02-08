using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BVNVerificationRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "bvn";

        [JsonProperty("bvn")]
        public string BVN { get; set; }
    }
}
