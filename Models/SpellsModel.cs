using System.Text.Json;

namespace advanced_APIS.Models
{
    public class SpellsModel
    {
        public List<Spell>? GetAllSpells()
        {
            var jsonSpells = File.ReadAllText("Resources\\Spells.json");
            List<Spell> spellList = JsonSerializer.Deserialize<List<Spell>>(jsonSpells);
            return spellList;
        }
    }
}
