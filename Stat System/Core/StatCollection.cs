
using System.Collections.Generic;

namespace UniversalStatSystem.Core
{
    public class StatCollection
    {
        private readonly Dictionary<StatType, CharacterStat> _stats = new();

        public void Add(CharacterStat stat)
        {
            _stats.Add(stat.Type, stat);
        }
        public CharacterStat Get(StatType type)
        {
            return _stats[type];
        }
        public bool TryGet(StatType type, out CharacterStat stat)
        {
            return _stats.TryGetValue(type, out stat);
        }
        public bool Contains(StatType type)
        {
            return _stats.ContainsKey(type);
        }
        public IEnumerable<CharacterStat> GetAll()
        {
            return _stats.Values;
        }
    }
}