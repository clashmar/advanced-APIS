using System.Text.Json;

namespace advanced_APIS.Models
{
    public class WizardsModel
    {
        private const string spellsPath = "Resources\\Spells.json";
        private const string teachersPath = "Resources\\Teachers.json";

        public List<Spell> GetAllSpells()
        {
            return Deserialize<Spell>(spellsPath);
        }
        
        public List<Teacher> GetAllTeachers()
        {
            return Deserialize<Teacher>(teachersPath);
        }

        public Teacher? GetTeacherById(int id)
        {
            List<Teacher> teachers = Deserialize<Teacher>(teachersPath);
            return teachers.Find(t => t.Id == id);
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            List<Teacher> teachers = Deserialize<Teacher>(teachersPath);

            int newId = teachers.Select(obj => obj.Id).Max() + 1;
            teacher.Id = newId;

            teachers.Add(teacher);
            Serialize<Teacher>(teachersPath, teachers);
            return teacher;
        }

        private void Serialize<T>(string path, List<T> data)
        {
            string jsonText = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonText);
        }

        private List<T> Deserialize<T>(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<T> data = JsonSerializer.Deserialize<List<T>>(jsonText) ?? [];
            return data;
        }


    }
}
