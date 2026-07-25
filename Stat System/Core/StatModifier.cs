namespace UniversalStatSystem.Core
{
    public enum ModifierType
    {
        flat,
        percent,
        multiplier,
        ovveride,
    }
    public class StatModifier
    {
        public StatType StatType {get;}
        public ModifierType ModifierType {get;}
        public float Value {get;}
        public object Source {get;}

        public StatModifier(StatType statType, ModifierType modifierType, float value, object source)
        {
            StatType = statType;
            ModifierType = modifierType;
            Value = value;
            Source = source;
        }
        
    }
}