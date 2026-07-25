using System;

namespace UniversalStatSystem.Core
{
    public class StatSystem
    {
        private readonly StatCollection  stats =  new();
        private readonly ModifierCollection modifiers = new();

        private readonly StatEngine engine;

        public StatSystem()
        {
            engine = new StatEngine(stats, modifiers);
        }

        public float GetValue(StatType type)
        {
            return stats.Get(type).CurrentValue;
        }

        public float GetBaseValue(StatType type)
        {
            return stats.Get(type).BaseValue;
        }

        public void AddModifier(StatModifier modifier)
        {
            if (modifier == null)
            throw new ArgumentException(nameof(modifier));
            modifiers.Add(modifier);
            engine.RecalculateAll();
        }
        public bool RemoveModifier(StatModifier modifier)
        {
            if (modifier == null)
            throw new ArgumentException(nameof(modifier));
            bool remove = modifiers.Remove(modifier);
            if(remove) engine.RecalculateAll();
            return remove;
        }

        public int RemoveModifierBySource(object source)
        {
            int remove = modifiers.RemoveBySource(source);
            if (remove > 0) engine.RecalculateAll();

            return remove;
        }
        public bool HasStat(StatType type)
        {
            return stats.Contains(type);
        }

        // only gonna use while defining the initial stats we are not gonna ovverride the base stat
        public void AddStat(StatType type, float baseValue)
        {
            stats.Add(new CharacterStat(type, baseValue));
        }
        // especially for leveling up the stats
        public void SetBaseValue(StatType type, float newValue)
        {
            stats.Get(type).SetBaseValue(newValue);
            engine.RecalculateAll();
        }
    }
    
}
