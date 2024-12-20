using advanced_APIS.Models;

namespace advanced_APIS.Services
{
    public class WizardsService
    {
        private readonly WizardsModel _wizardsModel;

        public WizardsService(WizardsModel spellsModel)
        {
            _wizardsModel = spellsModel;
        }

        public List<Spell>? GetSpells()
        {
            return _wizardsModel.GetAllSpells();
        }

        public List<Teacher>? GetTeachers()
        {
            return _wizardsModel.GetAllTeachers();
        }

        public Teacher? GetTeacherById(int id)
        {
            return _wizardsModel.GetTeacherById(id);
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            return _wizardsModel.AddTeacher(teacher);
        }
    }
}
