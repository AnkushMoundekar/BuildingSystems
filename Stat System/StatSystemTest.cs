using UnityEngine;
using UniversalStatSystem.Core;
public class StatSystemTest: MonoBehaviour
{
    StatCollection stats = new();
    ModifierCollection modifiers = new();
    object sword =  new();
    object sheild = new();
    object ring =  new();

    private void Awake() {
        Test();
    }
    public void Test()
    {
        Debug.Log("Testing.....");
        StatEngine engine = new StatEngine(stats, modifiers);
        stats.Add(new UniversalStatSystem.Core.CharacterStat(UniversalStatSystem.Core.StatType.Strength, 10f));
        stats.Add(new UniversalStatSystem.Core.CharacterStat(UniversalStatSystem.Core.StatType.Agility, 10f));
        float currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        float currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;

        Debug.Log($"Base stats \nStrength - {currentStength}\nAgility - {currentAgility}");
        
        modifiers.Add(
            new UniversalStatSystem.Core.StatModifier(
                UniversalStatSystem.Core.StatType.Strength,
                UniversalStatSystem.Core.ModifierType.flat,
                10f,
                sword
            )
        );
        modifiers.Add(
            new UniversalStatSystem.Core.StatModifier(
                UniversalStatSystem.Core.StatType.Agility,
                UniversalStatSystem.Core.ModifierType.flat,
                10f,
                ring
            )
        );
        modifiers.Add(
            new UniversalStatSystem.Core.StatModifier(
                UniversalStatSystem.Core.StatType.Strength,
                UniversalStatSystem.Core.ModifierType.flat,
                5f,
                sheild
            )
        );

        Debug.Log("Equiping Sword, Ring, Sheild");
        engine.RecalculateAll();
        currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;
        Debug.Log($"Strength - {currentStength}\nAgility - {currentAgility}");

        engine.RecalculateAll();
        currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;
        Debug.Log($"Checking Again \nStrength - {currentStength}\nAgility - {currentAgility}");

        engine.RecalculateAll();
        currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;
        Debug.Log($"Checking once Again \nStrength - {currentStength}\nAgility - {currentAgility}");

        modifiers.RemoveBySource(sword);
        Debug.Log("Unequping the Sword");
        engine.RecalculateAll();
        currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;
        Debug.Log($"Checking once Again \nStrength - {currentStength}\nAgility - {currentAgility}");
        
        engine.RecalculateAll();
        currentStength = stats.Get(UniversalStatSystem.Core.StatType.Strength).CurrentValue;
        currentAgility = stats.Get(UniversalStatSystem.Core.StatType.Agility).CurrentValue;
        Debug.Log($"Checking Again \nStrength - {currentStength}\nAgility - {currentAgility}");
    }

}