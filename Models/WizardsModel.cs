using System.Text.Json;

namespace advanced_APIS.Models
{
    public class WizardsModel
    {
        public List<Spell>? GetAllSpells()
        {
            var jsonSpells = File.ReadAllText("Resources\\Spells.json");
            List<Spell> spellList = JsonSerializer.Deserialize<List<Spell>>(jsonSpells) ?? [];
            return spellList;
        }
        
        public List<Teacher>? GetAllTeachers()
        {
            var jsonTeachers = File.ReadAllText("Resources\\Teachers.json");
            List<Teacher> teacherList = JsonSerializer.Deserialize<List<Teacher>>(jsonTeachers) ?? [];
            return teacherList;
        }

        public Teacher? GetTeacherById(int id)
        {
            List<Teacher>? teachers = GetAllTeachers() ?? [];
            return teachers.Find(t => t.Id == id);
        }
    }
}
