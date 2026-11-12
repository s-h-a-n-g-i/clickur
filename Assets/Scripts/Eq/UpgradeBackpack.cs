using TMPro;
using UnityEngine;

public class UpgradeBackpack : MonoBehaviour
{
    [SerializeField] private Transform parentToSlot;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private TMP_Text text;
    public void BuyUpgrade() 
    {
        if (LudekManager.instance.character.money >= GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID).Length * 10)
        {
            Instantiate(slotPrefab, parentToSlot, false);
            LudekManager.instance.character.money -= GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID).Length * 10;
            text.text = "Upgrade Backpack: " + GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID).Length * 10+"$";
        }
        if(GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID).Length==15)
            gameObject.SetActive(false);
    }

    private void Start()
    {
        text.text = "Upgrade Backpack: 10$";
    }
}
