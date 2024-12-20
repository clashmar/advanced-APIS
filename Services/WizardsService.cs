using advanced_APIS.Models;

namespace advanced_APIS.Services
{
    public class WizardsService
    {
        private readonly WizardsModel _spellsModel;

        public WizardsService(WizardsModel spellsModel)
        {
            _spellsModel = spellsModel;
        }

        public List<Spell>? GetSpells()
        {
            return _spellsModel.GetAllSpells();
        }

        public List<Teacher>? GetTeachers()
        {
            return _spellsModel.GetAllTeachers();
        }
    }
}
