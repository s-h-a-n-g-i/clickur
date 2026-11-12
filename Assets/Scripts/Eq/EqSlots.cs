using UnityEngine;
using UnityEngine.UI;

public class EqSlots : MonoBehaviour
{
    [SerializeField] private Sprite itemUnequipped;
    [SerializeField] private Sprite itemEquipped;

    private Image img;

    public bool isEquipped = false;
    public ItemType itemtype;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if(isEquipped)
            img.sprite = itemEquipped;
        else
            img.sprite = itemUnequipped;
    }
}
