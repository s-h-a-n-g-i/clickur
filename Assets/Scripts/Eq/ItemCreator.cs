using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemStats))]
public class ItemCreator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image rarityImage;
    [SerializeField] private Image ItemImage;
    [SerializeField] private SO_Item[] itemsToRoll;
    [Header("Kolory rzadkosci")]
    [SerializeField] private Color poor;
    [SerializeField] private Color common;
    [SerializeField] private Color rare;
    [SerializeField] private Color ultra_rare;
    [SerializeField] private Color legendary;
    [SerializeField] private Color mythic;
    [Header("Popup Objects")]
    [SerializeField] private GameObject popup;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text statsText;





    private ItemRarity rarity;
    private ItemStats stats;
    SO_Item item;
    private void Start()
    {
        stats = GetComponent<ItemStats>();//poldek to cwel
        CreateItem();
    }

    private void CreateItem() 
    {
        item = itemsToRoll[Random.Range(0, itemsToRoll.Length)];
        
        rarity = CheckRarity();
        ItemImage.sprite = item.ImageItem;
        SetupStats();
    }


    private void SetupStats()
    {
        stats.rarity = rarity;
        nameText.text = rarity.ToString() +" "+ item.itemName;
        float luck = (float)LudekManager.instance.character.luck;

        int randomStat = (int)Random.Range(1 + luck, 2 + (luck * 2)) + 1* (int)stats.rarity;

        stats.type = item.typeItem;
        switch (item.typeItem) 
        {
            case ItemType.weapon:
                stats.damage = randomStat;
                statsText.text = "Damage:" + stats.damage;
                break;
            case ItemType.helmet:
                stats.inteligence = randomStat;
                statsText.text = "Inteligencr:" + stats.inteligence;
                break;
            case ItemType.chestplate:
                stats.lethality = randomStat;
                statsText.text = "Lethality:" + stats.lethality;
                break;
            case ItemType.leggings:
                stats.wisdom = randomStat;
                statsText.text = "Wisdom:" + stats.wisdom;
                break;
        }
    }

    private ItemRarity CheckRarity() 
    {
        float luck = (float)LudekManager.instance.character.luck;
        double rand = Random.Range(luck-50,luck+50);
        if (rand < 50)
        {
            rarityImage.color = poor;
            nameText.color = poor;
            return ItemRarity.poor;
        }
        else if (rand >= 50 && rand < 100)
        {
            rarityImage.color = common;
            nameText.color = common;
            return ItemRarity.common;
        }
        else if (rand >= 100 && rand < 150)
        {
            rarityImage.color = rare;
            nameText.color = rare;
            return ItemRarity.rare;
        }
        else if (rand >= 150 && rand < 200)
        {
            rarityImage.color = ultra_rare;
            nameText.color = ultra_rare;
            return ItemRarity.ultra_rare;
        }
        else if (rand >= 200 && rand < 250)
        {
            rarityImage.color = legendary;
            nameText.color = legendary;
            return ItemRarity.legendary;
        }
        rarityImage.color = mythic;
        nameText.color = mythic;
        return ItemRarity.mythic;
    }

    public void PopupOpen() 
    {
        popup.SetActive(true);
    }
}
