using System;
using UnityEngine;

public class LudekManager : MonoBehaviour
{
    public static LudekManager instance { get; set; }

    public C_Character character;
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        
        instance = this;
        DontDestroyOnLoad(this);
        
        character = new C_Character();

    }


    public static implicit operator CharacterController(LudekManager v)
    {
        throw new NotImplementedException();
    }
}
