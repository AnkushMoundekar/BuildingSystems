using System.Collections.Generic;

namespace UniversalStatSystem.Core
{
    public class ModifierCollection
    {
        private readonly List<StatModifier> statModifiers = new();
        public void Add(StatModifier statModifier)
        {
            statModifiers.Add(statModifier);
        }
        public bool Remove(StatModifier statModifier)
        {
            return statModifiers.Remove(statModifier);
        }
        public int RemoveBySource(object source)
        {
            return statModifiers.RemoveAll(modifier => modifier.Source == source);
        }
        public IEnumerable<StatModifier> GetStatModifiers(StatType statType)
        {
            foreach (var modifier in statModifiers)
            {
                if (modifier.StatType == statType)
                {
                    yield return modifier;
                }
            }
        }
        public void Clear()
        {
            statModifiers.Clear();
        }
        public int Count => statModifiers.Count;
    }
}