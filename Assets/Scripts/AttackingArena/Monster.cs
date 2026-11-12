using FMODUnity;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int bossCount = 1;
    [SerializeField] private double monsterHp = 1000;
    [SerializeField] private double monsterHpMax = 1000;
    [SerializeField] private double monsterShield = 0;

    [SerializeField] private float imageSize;

    [Header("Hp Images")]
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private Image image;
    [Header("Monster")]
    [SerializeField] private Animator animMonster;
    [SerializeField] private SpriteRenderer monsterImage;
    [SerializeField] private Sprite[] monsterSprites;
    [Header("Items Eq")]
    [SerializeField] private EqSlotManager eqManager;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject helmet;
    [SerializeField] private GameObject chestplate;
    [SerializeField] private GameObject leggings;
    [SerializeField] private TMP_Text itemcost;
    [Header("Particles")]
    [SerializeField] private ParticleSystem boomParticle;
    [SerializeField] private ParticleSystem slashParticle;

    [SerializeField] private EventReference track;

    private float timeToDealDamge = 0;

    void Start()
    {
        monsterImage.sprite = monsterSprites[0];
        armorText.text = "0";
        imageSize = 300;
        itemcost.text = "Buy item: 500$";
    }

    void Update()
    {

        if (monsterHp <= 0)
            MonsterDie();
        UpdateImageAndText();

        if (LudekManager.instance.character.wisdom > 0)
            passiveDamage();

    }

    public void DealDamage()
    {
        
        float critChance = Random.Range(0, 100);
        double dmgS = LudekManager.instance.character.luck % 100;
        int damageMultiplier = (int)(LudekManager.instance.character.luck / 100) +1;
        if (critChance >= dmgS)
            damageMultiplier++;
        if (critChance < LudekManager.instance.character.luck) { }

        double damageReduction = monsterShield - (LudekManager.instance.character.lethality + getChestplateStats());
        double damage = getWeaponStats() + LudekManager.instance.character.damage - damageReduction;
        if(damage<0)
            damage = 0;
        slashParticle.Emit(1);
        ApplyDamage(damage* damageMultiplier);
    }

    private void passiveDamage()
    {
        timeToDealDamge += Time.deltaTime;

        if (timeToDealDamge <= 30 / (LudekManager.instance.character.wisdom + getLeggingsStats())) return;

        double damage = LudekManager.instance.character.inteligence + getHelmetStats();
        boomParticle.Emit(1);
        RuntimeManager.PlayOneShot(track);

        ApplyDamage(damage);
        timeToDealDamge = 0;
    }

    private void ApplyDamage(double damage)
    {
        animMonster.SetTrigger("Damage");
        monsterHp -= damage;
        LudekManager.instance.character.money += damage;
    }


    //💀💀💀
    private void MonsterDie()
    {
        eqManager.AddItemFromPool();
        LudekManager.instance.character.money += monsterHpMax/100;
        monsterHpMax += monsterHpMax;
        monsterHp = monsterHpMax;
        bossCount++;
        monsterShield = (bossCount-1)*3*bossCount;
        armorText.text = monsterShield.ToString();
        int cwel = (int)Random.Range(0.1f, 1.9f);
        monsterImage.sprite = monsterSprites[cwel];
        itemcost.text = "Buy item: "+ bossCount * 500+"$";
    }

    private void UpdateImageAndText()
    {
        hpText.text = monsterHp.ToString("F2") + " / " + monsterHpMax;
        float xMove = ((imageSize * ((float)monsterHp / (float)monsterHpMax)) - imageSize) * 2;
        image.rectTransform.localPosition = new Vector3(xMove, image.rectTransform.localPosition.y, 0);
    }

    public void BuyItem() 
    {
        int cost = bossCount * 500;
        if (LudekManager.instance.character.money >= cost)
        {
            LudekManager.instance.character.money -= cost;
            eqManager.AddItemFromPool();
        }
    }


    public double getWeaponStats() 
    {
        if(weapon.transform.childCount==0) return 0;
        return weapon.transform.GetChild(0).GetComponent<ItemStats>().GetStats();
    }
    public double getHelmetStats()
    {
        if (helmet.transform.childCount == 0) return 0;
        return helmet.transform.GetChild(0).GetComponent<ItemStats>().GetStats();
    }
    public double getChestplateStats()
    {
        if (chestplate.transform.childCount == 0) return 0;
        return chestplate.transform.GetChild(0).GetComponent<ItemStats>().GetStats();
    }
    public double getLeggingsStats()
    {
        if (leggings.transform.childCount == 0) return 0;
        return leggings.transform.GetChild(0).GetComponent<ItemStats>().GetStats();
    }


}
