using System.Text.Json.Serialization;

namespace advanced_APIS.Models
{
    public class Spell
    {
        [JsonPropertyName("id")]
        int Id { get; set; }
        [JsonPropertyName("name")]
        string? Name { get; set; } = "";
        [JsonPropertyName("description")]
        string? Description { get; set; } = "";
        [JsonPropertyName("casting_instructions")]
        string? CastingInstructions { get; set; } = "";
    }
}
