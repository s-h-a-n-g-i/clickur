using System.Collections.Generic;
using UnityEngine;

public class EqSlotManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotsActive;
    [SerializeField] private GameObject itemPrefab;
    //🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥
    public GameObject GetFirstFreeItemSlot() 
    {
        foreach (var slot in slotsActive) 
        {
            if (!slot.GetComponent<Slot>().isSlotFull)
            {
                slot.GetComponent<Slot>().isSlotFull = true;
                return slot;
            }
        }
        return null;
    }

    private void Update()
    {
        if (GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID).Length != slotsActive.Count - 1)
        {
            AddSlots(GameObject.FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID));
        }
    }

    private void AddSlots(Slot[] slots) 
    {
        slotsActive.Clear();
        foreach (Slot s in slots) 
        {
            slotsActive.Add(s.gameObject);
        }

    }
    public void AddItemFromPool() 
    {
        GameObject parent = GetFirstFreeItemSlot();
        if (parent == null) return;

        Instantiate(itemPrefab, parent.transform);

    }
}
