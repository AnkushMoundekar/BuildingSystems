using UnityEngine;

public class EntityStatModifierController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private StatSystem targetStatSystem;

    [Header("Current Equipment State")]
    private EquipmentItemSO _equippedWeapon;
    private EquipmentItemSO _equippedArmor;

    public void EquipWeapon(EquipmentItemSO newWeapon)
    {
        // 1. Strip old weapon modifiers if already wearing one
        if (_equippedWeapon != null)
        {
            _equippedWeapon.UnEquip(targetStatSystem);
        }

        // 2. Apply new weapon modifiers
        _equippedWeapon = newWeapon;
        if (_equippedWeapon != null)
        {
            _equippedWeapon.Equip(targetStatSystem);
            Debug.Log($"[{gameObject.name}] Successfully equipped weapon: {_equippedWeapon.itemName}");
        }
    }
    public void UnequipWeapon()
    {
        if (_equippedWeapon != null)
        {
            _equippedWeapon.UnEquip(targetStatSystem);
            Debug.Log($"[{gameObject.name}] Unequipped weapon: {_equippedWeapon.itemName}");
            _equippedWeapon = null;
        }
    }
    public void ConsumePotion(ConsumableItemSO potion)
    {
        if (potion != null)
        {
            // Pass 'this' as the MonoBehaviour to anchor the asynchronous duration timer coroutine
            potion.Consume(this, targetStatSystem);
            Debug.Log($"[{gameObject.name}] Consumed buff potion: {potion.potionName}");
        }
    }
}
