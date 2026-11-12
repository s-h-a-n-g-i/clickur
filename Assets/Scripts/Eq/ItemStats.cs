using TMPro;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public ItemRarity rarity;
    public string itemName;

    public double damage = 0;
    public double lethality = 0;
    public double inteligence = 0;
    public double wisdom = 0;
    public double luck = 0;
    public double sellCost = 0;
    public ItemType type;

    [SerializeField] private TMP_Text sellText;

    private void Start()
    {
        sellCost = (damage + lethality + inteligence + wisdom + luck)*0.25d;
        sellText.text = "Sell "+sellCost+"$";
    }
    public void Equip() 
    {
        EqSlots[] slots = GameObject.FindObjectsByType<EqSlots>(0);
        foreach (EqSlots slot in slots) 
            if (slot.itemtype == type)
                if (slot.isEquipped)
                    SwapItem(slot.gameObject.transform,slot.gameObject.transform.GetChild(0));
                else
                    EquipItem(slot.gameObject.transform);
    }

    private void SwapItem(Transform slotToEquip,Transform itemToSwap) 
    {
        Transform parent = transform.parent;

        transform.SetParent(slotToEquip,false);
        itemToSwap.SetParent(parent, false);

    }

    private void EquipItem(Transform slotToEquip)
    {
        Slot parent = transform.parent.GetComponent<Slot>();
        parent.isSlotFull = false;
        transform.SetParent(slotToEquip, false);

        slotToEquip.GetComponent<EqSlots>().isEquipped = true;
    }

    //public void Deequip()
    //{
    //    Slot parent = transform.parent.GetComponent<Slot>();
    //}
    public void Sell()
    {
        if (transform.parent.GetComponent<EqSlots>())
            transform.parent.GetComponent<EqSlots>().isEquipped = false;
        if (transform.parent.GetComponent<Slot>())
            transform.parent.GetComponent<Slot>().isSlotFull = false;
        LudekManager.instance.character.money += sellCost;
        Destroy(gameObject);
    }

    public double GetStats() 
    {
        return damage + lethality + inteligence + wisdom;
    }

}