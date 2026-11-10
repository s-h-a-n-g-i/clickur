using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName ="ScriptableObjects/Items",order = 0)]
public class SO_Item : ScriptableObject
{
    public string itemName = "ITEM_NAME";
    public Sprite ImageItem;
    public ItemType typeItem;

}

public enum ItemRarity
{
    poor,
    common,
    rare,
    ultra_rare,
    legendary,
    mythic
}

public enum ItemType
{
    weapon,
    helmet,
    chestplate,
    leggings
}