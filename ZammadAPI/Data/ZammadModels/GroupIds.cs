using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class GroupIds
    {
        [JsonPropertyName("1")]
        public List<string> Ids { get; set; }

    }
}
