using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Channel
    {
        [JsonPropertyName("email")]
        public bool Email { get; set; }

        [JsonPropertyName("online")]
        public bool Online { get; set; }
    }
}
