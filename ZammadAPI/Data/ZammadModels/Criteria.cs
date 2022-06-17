using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class Criteria
    {
        [JsonPropertyName("owned_by_me")]
        public bool OwnedByMe { get; set; }

        [JsonPropertyName("owned_by_nobody")]
        public bool OwnedByNobody { get; set; }

        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }

        [JsonPropertyName("no")]
        public bool No { get; set; }
    }
}
