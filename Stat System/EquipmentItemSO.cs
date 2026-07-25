using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipment", menuName = "Items/Equipments")]
public class EquipmentItemSO: ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public StatBonusData[] bonuses;

    public void Equip(StatSystem playerStat)
    {
        foreach(var bonus in bonuses)
        {
            playerStat.ApplyModifier(bonus.statToModify, bonus.value, bonus.modificationType, this);
        }
    }
    public void UnEquip(StatSystem playerStat)
    {
        foreach(var bonus in bonuses)
        {
            playerStat.RemoveModifierfromSource(bonus.statToModify, this);
        }
    }
}
