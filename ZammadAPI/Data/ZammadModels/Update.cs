using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Update
    {
        [JsonPropertyName("criteria")]
        public Criteria? Criteria { get; set; }

        [JsonPropertyName("channel")]
        public Channel? Channel { get; set; }
    }
}
