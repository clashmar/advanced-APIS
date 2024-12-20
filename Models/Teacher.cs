using System.Text.Json.Serialization;

namespace advanced_APIS.Models
{
    public class Teacher
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("species")]
        public string? Species { get; set; } = "";

        [JsonPropertyName("personality")]
        public string? Personality { get; set; } = "";

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("teaches")]
        public List<string>? Teaches { get; set; }
    }
}