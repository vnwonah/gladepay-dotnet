using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class ChargeableBankListRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "supported_chargable_banks";
    }
}
