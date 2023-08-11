using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField] Transform slotParent;
    [SerializeField] Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
    private void Awake()
    {
        FreshSlot();
    }
    public void FreshSlot()
    {
        int i = 0;
        for(; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for(; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void AddItem(Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("½½·ÔÀÌ °¡µæÂü");
        }
    }
    private void OnDisable()
    {
        items = null;
    }
}
public interface IObjectItem
{
    Item ClickItem();
}
