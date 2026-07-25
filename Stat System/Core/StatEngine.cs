namespace UniversalStatSystem.Core
{
    public class StatEngine
    {
        private readonly StatCollection _statCollection;
        private readonly ModifierCollection _modifierCollection;

        public StatEngine(StatCollection statCollection, ModifierCollection modifierCollection)
        {
            _statCollection = statCollection;
            _modifierCollection = modifierCollection; 
        }

        public void RecalculateAll()
        {
            foreach(var stat in _statCollection.GetAll())
            {
                float currentValue = stat.BaseValue;

                foreach(var modifier in _modifierCollection.GetStatModifiers(stat.Type))
                {
                    // calculate the current value by type
                    currentValue += modifier.Value;
                }
                stat.SetCurrentValue(currentValue);
            }
        }
    }
    
}
