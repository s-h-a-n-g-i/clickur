using Unity.VisualScripting;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    public typeUpgrade upgrade; 
    private void Update()
    {
        
    }
    public void ClickButton() 
    {
        if (!Buy()) return;
        switch (upgrade)
        {
            case typeUpgrade.damage:
                LudekManager.instance.character.damage += 0.25;
                break;
            case typeUpgrade.wisdom:
                LudekManager.instance.character.wisdom += 0.25;
                break;
            case typeUpgrade.luck:
                LudekManager.instance.character.luck += 0.25;
                break;
            case typeUpgrade.lethality:
                LudekManager.instance.character.lethality += 0.25;
                break;
            case typeUpgrade.inteligence:
                LudekManager.instance.character.inteligence+=0.25;
                break;
        }

    }
    private bool Buy() 
    {
        double price = CostToBuy();
        double money = LudekManager.instance.character.money;
        if (money < price) return false;
        double s = TakeStat() + 0.25;
        LudekManager.instance.character.money -= price;
        return true;
    }

    public double CostToBuy() 
    {
        double stat = TakeStat();
        return ((stat/0.25)*2)+2;
        
    }

    public double TakeStat() 
    {
        switch (upgrade)
        {
            case typeUpgrade.damage:
                return LudekManager.instance.character.damage;
            case typeUpgrade.wisdom:
                return LudekManager.instance.character.wisdom;
            case typeUpgrade.luck:
                return LudekManager.instance.character.luck;
            case typeUpgrade.lethality:
                return LudekManager.instance.character.lethality;
            case typeUpgrade.inteligence:
                return LudekManager.instance.character.inteligence;
        }
        return 0;
    }

}
