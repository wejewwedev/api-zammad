using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Escalation
    {
        [JsonPropertyName("criteria")]
        public Criteria Criteria { get; set; }

        [JsonPropertyName("channel")]
        public Channel Channel { get; set; }
    }
}
