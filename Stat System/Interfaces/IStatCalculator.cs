using System.Collections.Generic;

public interface IStatCalculator
{
    public float Calculate(float baseValue, IReadOnlyList<StatModifier> statModifiers);
}