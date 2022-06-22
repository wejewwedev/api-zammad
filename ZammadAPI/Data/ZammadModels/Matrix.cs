using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Matrix
    {
        [JsonPropertyName("create")]
        public Create? Create { get; set; }

        [JsonPropertyName("update")]
        public Update? Update { get; set; }

        [JsonPropertyName("reminder_reached")]
        public ReminderReached? ReminderReached { get; set; }

        [JsonPropertyName("escalation")]
        public Escalation? Escalation { get; set; }
    }
}
