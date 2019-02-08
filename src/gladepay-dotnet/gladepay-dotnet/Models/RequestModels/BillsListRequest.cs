using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class BillsListRequest
    {
        [JsonProperty("action")]
        public const string Action = "pull";
    }
}
