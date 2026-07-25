using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Items/Consumables")]
public class ConsumableItemSO : ScriptableObject
{
    public string potionName;
    public float durationInSeconds;
    public StatBonusData[] bonuses;

    public void Consume(MonoBehaviour runner, StatSystem playerStats)
    {
        runner.StartCoroutine(PotionDurationRoutine(playerStats));
    }
    IEnumerator PotionDurationRoutine(StatSystem playerStats)
    {
        foreach(var bonus in bonuses)
        {
            playerStats.ApplyModifier(bonus.statToModify, bonus.value, bonus.modificationType, this);
        }

        yield return new WaitForSeconds(durationInSeconds);

        foreach(var bonus in bonuses)
        {
            playerStats.RemoveModifierfromSource(bonus.statToModify, this);
        }
    }
}
