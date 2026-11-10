using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EqSlotManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotsActive;
    [SerializeField] private GameObject itemPrefab;

    public GameObject GetFirstFreeItemSlot() 
    {
        foreach (var slot in slotsActive) 
        {
            if (!slot.GetComponent<SlotManager>().isSlotFull)
            {
                slot.GetComponent<SlotManager>().isSlotFull = true;
                return slot;
            }
        }
        return null;
    }


    public void AddItemFromPool() 
    {
        GameObject parent = GetFirstFreeItemSlot();
        if (parent == null) return;

        Instantiate(itemPrefab, parent.transform);

    }
}
