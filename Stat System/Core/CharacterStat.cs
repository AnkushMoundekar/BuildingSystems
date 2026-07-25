namespace UniversalStatSystem.Core{
    public enum StatType
    {
        Strength,
        Agility,
        Intelligence,
        Vitality,
    }
    public class CharacterStat
    {
        public StatType Type {get;}
        public float BaseValue {get; private set;}
        public float CurrentValue {get; private set;}

        public CharacterStat(StatType type, float value)
        {
            Type = type;
            BaseValue = value;
            CurrentValue = value;
        }
        public void SetCurrentValue(float value)
        {
            CurrentValue = value;
        }
        public void SetBaseValue(float value)
        {
            BaseValue =  value;
        }
    }
    
}

