public enum StatType
{
    Strength,
    Agility,
    Intelligence,
    Vitality,
    MaxHealth,
    MaxMana,
}
public enum ModifierType
{
    Flat,
    Percent
}
public class StatModifier
{
    public float Value {get; private set;}
    public ModifierType Type {get; private set;}
    public object Source {get; private set;}

    public StatModifier(float value, ModifierType type, object source)
    {
        Value = value;
        Type = type;
        Source = source;
    }
}
