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
    [SerializeField] private RawImage monsterImage;
    [SerializeField] private RawImage image;
    [Header("Monster")]
    [SerializeField] private Animator animMonster;

    void Start()
    {
        imageSize = 300;
    }

    void Update()
    {
        if (monsterHp <= 0)
            MonsterDie();
        UpdateImageAndText();
    }

    public void DealDamage()
    {
        animMonster.SetTrigger("Damage");
        
        double damageReduction = monsterShield - LudekManager.instance.character.lethality;
        if(damageReduction<0)
            damageReduction = 0;
        double damage = LudekManager.instance.character.damage - damageReduction;
        if(damage<0)
            damage = 0;
        
        monsterHp -= damage;
        LudekManager.instance.character.money += damage;
    }

    private void passiveDamage() 
    {
        
    }

    private void MonsterDie()
    {
        LudekManager.instance.character.money += monsterHpMax/100;
        monsterHpMax += monsterHpMax;
        monsterHp = monsterHpMax;
        bossCount++;
        monsterShield = (bossCount-1)*3;
    }

    private void UpdateImageAndText()
    {
        hpText.text = monsterHp + " / " + monsterHpMax;
        float xMove = ((imageSize * ((float)monsterHp / (float)monsterHpMax)) - imageSize) * 2;
        image.rectTransform.localPosition = new Vector3(xMove, image.rectTransform.localPosition.y, 0);
        //UnityEngine.Debug.Log(xMove);
    }
}
