using System;
using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class RecurringTransactionsListRequest
    {
        [JsonProperty("inquire")]
        public const string Inquire = "recurrents";
    }
}
