
using System;
using System.Collections.Generic;

public class CharacterStat 
{
    public StatType Type {get; private set;}
    public float BaseValue;
    public int AllocatedPoints {get; private set;}

    private float _cachedValue;
    private bool _isDirty = true;

    private readonly List<StatModifier> _modifiers = new List<StatModifier>();

    public CharacterStat(StatType type, float baseValue)
    {
        Type = type;
        BaseValue = baseValue;
        AllocatedPoints = 0;
    }

    public void AllocatePoints(int amountPerPoint = 1)
    {
        AllocatedPoints+=amountPerPoint;
        _isDirty = true;
    }

    public float Value
    {
        get
        {
            if(!_isDirty) return _cachedValue;

            _cachedValue = CalculateFinalValue();
            _isDirty = false;
            return _cachedValue;
        }
    }
    public void AddModifier(StatModifier modifier)
    {
        _modifiers.Add(modifier);
        _isDirty = true;
    }
    public bool RemoveModifierfromSource(object source)
    {
        bool didRemove = false;

        for(int i=_modifiers.Count-1; i>=0; i--)
        {
            if(_modifiers[i].Source == source)
            {
                _modifiers.RemoveAt(i);
                _isDirty = true;
                didRemove = false;
            }
        }
        return didRemove;
    }
    private float CalculateFinalValue()
    {
        float finalValue = BaseValue + AllocatedPoints;
        float sumPercent = 0;

        for(int i=0; i<_modifiers.Count; i++)
        {
            StatModifier mod = _modifiers[i];
            if(mod.Type == ModifierType.Flat)
            {
                finalValue+=mod.Value;
            }
            else if(mod.Type == ModifierType.Percent)
            {
                sumPercent += (float)Math.Round(mod.Value/100,2);
            }
        }

        if (sumPercent >= 0)
        {
            finalValue = (1+sumPercent)*finalValue;
        }
        return (float)Math.Round(finalValue,2);
    }

}
