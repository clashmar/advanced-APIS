using System.Text.Json.Serialization;

namespace advanced_APIS.Models
{
    public class Spell
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; } = "";
        [JsonPropertyName("description")]
        public string? Description { get; set; } = "";
        [JsonPropertyName("casting_instructions")]
        public string? CastingInstructions { get; set; } = "";
    }
}
