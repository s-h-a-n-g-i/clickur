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
            tmp.text = string.Format(CultureInfo.InvariantCulture, "{0}", LudekManager.instance.character.money) + "$";
        else
            tmp.text = string.Format(CultureInfo.InvariantCulture, "{0}", LudekManager.instance.character.gems) + "₡";
    }
}
