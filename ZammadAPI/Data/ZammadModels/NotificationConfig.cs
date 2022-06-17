using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class NotificationConfig
    {
        [JsonPropertyName("matrix")]
        public Matrix Matrix { get; set; }
    }
}
