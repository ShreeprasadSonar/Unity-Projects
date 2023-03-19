using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public int space = 3;
    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);
        Debug.Log(item.itemName + " was added.");
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems(){
        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName")?.GetComponent<TextMeshProUGUI>();
            var itemImage = obj.transform.Find("ItemImage")?.GetComponent<Image>();

            itemName.text = item.itemName;
            itemImage.sprite = item.itemImage;
        }
    }

    public void PlaceItem(Item item){
    
    }
}
