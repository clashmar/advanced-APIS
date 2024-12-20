using advanced_APIS.Models;

namespace advanced_APIS.Services
{
    public class SpellsService
    {
        private readonly SpellsModel _spellsModel;

        public SpellsService(SpellsModel spellsModel)
        {
            _spellsModel = spellsModel;
        }

        public List<Spell>? GetSpells()
        {
            return _spellsModel.GetAllSpells();
        }
    }
}
