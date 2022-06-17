using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Preferences
    {
        [JsonPropertyName("notification_config")]
        public NotificationConfig NotificationConfig { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("intro")]
        public bool Intro { get; set; }

        [JsonPropertyName("tickets_closed")]
        public int TicketsClosed { get; set; }

        [JsonPropertyName("tickets_open")]
        public int TicketsOpen { get; set; }
    }
}
