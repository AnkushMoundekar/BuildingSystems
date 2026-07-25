using System.Collections.Generic;
using UnityEngine;
using System;

public class StatSystem : MonoBehaviour
{
    [System.Serializable]
    public struct InitialStatConfig
    {
        public StatType statType;
        public float baseValue;
    }
    [Header("Base Character Configuration Sheet")]
    [Tooltip("Define the starting base stats for this specific prefab here.")]
    [SerializeField] private List<InitialStatConfig> startingStats = new List<InitialStatConfig>();
    private Dictionary<StatType, CharacterStat> _statPool = new Dictionary<StatType, CharacterStat>();
    public event Action<StatType, float> OnStatChanged;
    void Awake()
    {
        for(int i=0; i< startingStats.Count; i++)
        {
            InitializeStat(startingStats[i].statType, startingStats[i].baseValue);
        }
    }
    private void InitializeStat(StatType type, float baseValue)
    {
        _statPool.Add(type, new CharacterStat(type, baseValue));
        OnStatChanged?.Invoke(type, baseValue);
    }
    public float GetBaseStatValue(StatType type)
    {
        if(_statPool.TryGetValue(type, out var stat))
        {
            return stat.BaseValue + stat.AllocatedPoints;
        }
        return 0f;
    }
    public float GetStatValue(StatType type)
    {
        if(_statPool.TryGetValue(type, out var stat))
        {
            return stat.Value;
        }
        return 0f;
    }
    public void ApplyModifier(StatType type, float value, ModifierType modType, object source)
    {
        if(_statPool.TryGetValue(type, out var stat))
        {
            
            stat.AddModifier(new StatModifier(value, modType, source));

            OnStatChanged?.Invoke(type, GetStatValue(type));
        }
    }
    public void RemoveModifierfromSource(StatType type, object source)
    {
        if(_statPool.TryGetValue(type, out var stat))
        {
            stat.RemoveModifierfromSource(source);
            OnStatChanged?.Invoke(type, _statPool[type].Value);
        }
    }
    public void AllocatePointToStat(StatType type)
    {
        if(_statPool.TryGetValue(type, out var characterStat))
        {
            characterStat.AllocatePoints();
            OnStatChanged?.Invoke(type, _statPool[type].Value);
        }
    }
}