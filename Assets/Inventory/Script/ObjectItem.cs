using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectItem : MonoBehaviour, IObjectItem
{
    [Header("������")]
    public Item item;
    [Header("������ �̹���")]
    public SpriteRenderer itemImage;

    void Start()
    {
        itemImage.sprite = item.itemImage;
    }
    public Item ClickItem()
    {
        this.gameObject.SetActive(false);
        return this.item;
    }
}
