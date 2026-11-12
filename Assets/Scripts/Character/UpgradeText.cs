using System.Globalization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(UpgradeButtons))]
public class UpgradeText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text costText;
    private void Update()
    {
        text.text = GetComponent<UpgradeButtons>().upgrade.ToString() + ": "+ GetComponent<UpgradeButtons>().TakeStatWithItems();
        costText.text = "Upgrade "+string.Format(CultureInfo.InvariantCulture, "{0}", GetComponent<UpgradeButtons>().CostToBuy()) + "$";
    }
}
