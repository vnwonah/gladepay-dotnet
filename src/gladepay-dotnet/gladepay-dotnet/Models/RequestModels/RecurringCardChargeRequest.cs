using gladepay_dotnet.Enums;
using Newtonsoft.Json;

namespace gladepay_dotnet.Models.RequestModels
{
    public class RecurringCardChargeRequest : CardChargeRequest
    {
        [JsonProperty("recurrent")]
        public Recurrent Recurrent { get; set; }
    }


    public class Recurrent
    {
        /// <summary>
        /// Frequency of recurrent charge can be weekly, daily or monthly
        /// </summary>
        [JsonIgnore]
        public Frequency ChargeFrequency { get; set; }

        /// <summary>
        /// When using a daily frequency, the charge period is the time of the day when charge should occur between 00 (12AM) and 24 (12PM)
        /// When using a weekly frequency, the charge period is the day of the week when charge should occur between 1 (Sunday) and 7(Saturday)
        /// When using a Monthly frequency the charge period is the day of the month when charge should occur between 01 (1st day) and 30 (last day)
        /// </summary>
        [JsonProperty("value")]
        public string ChargePeriod { get; set; }

        [JsonProperty("frequency")]
        public string Frequency
        {
            get
            {
                return ChargeFrequency.ToString().ToLower();
            }
        }
    }
}
