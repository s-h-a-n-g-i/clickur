using UnityEngine;
using UnityEngine.UI;

public class ItemCreator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject popup;
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
    private ItemRarity rarity;

    SO_Item item;
    private void Start()
    {
        CreateItem();
    }

    private void CreateItem() 
    {
        item = itemsToRoll[Random.Range(0,0)];
        CheckRarity();
        rarity = CheckRarity();

    }

    private ItemRarity CheckRarity() 
    {
        float luck = (float)LudekManager.instance.character.luck;
        double rand = Random.Range(luck-50,luck+50);
        if (rand < 50)
        {
            rarityImage.color = poor;
            return ItemRarity.poor;
        }
        else if (rand < 50)
        {
            rarityImage.color = common;
            return ItemRarity.common;
        }
        else if (rand >= 50 && rand < 100)
        {
            rarityImage.color = rare;
            return ItemRarity.rare;
        }
        else if (rand >= 100 && rand < 150)
        {
            rarityImage.color = ultra_rare;
            return ItemRarity.ultra_rare;
        }
        else if (rand >= 200 && rand < 250)
        {
            rarityImage.color = legendary;
            return ItemRarity.legendary;
        }
        rarityImage.color = mythic;
        return ItemRarity.mythic;
    }

    public void PopupOpen() 
    {
        popup.SetActive(true);
    }

    

    void Update()
    {
        
    }
}
