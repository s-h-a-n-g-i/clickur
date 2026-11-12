using System.Globalization;
using TMPro;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    private TMP_Text tmp;
    [SerializeField] private bool gems = false;
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(!gems)
            tmp.text = LudekManager.instance.character.money.ToString("F2") + "$";
        else
            tmp.text = LudekManager.instance.character.gems.ToString("F2") + "₡";
    }
}
