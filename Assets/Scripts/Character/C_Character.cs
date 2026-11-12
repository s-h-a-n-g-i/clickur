using System;
using UnityEngine;
[Serializable]
public class C_Character
{
    public string name = "";

    public double money = 0;
    public double gems = 0;

    public double damage = 0.25;
    public double lethality = 0;
    public double inteligence = 0;
    public double wisdom = 0;
    public double luck = 0;


    public int ResetPoints = 0;
}

public enum typeUpgrade
{
    damage, lethality, inteligence, wisdom, luck
}