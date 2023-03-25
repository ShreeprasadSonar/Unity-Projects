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
    public GameObject InventoryPanel;
    public TMP_Text itemText;
    public List<GameObject> objects = new List<GameObject>();
    public GameObject mainCamera;
    public GameObject character;

    public InventoryItemController[] InventoryItems;
    private Button firstMenuItem;

    private void Start()
    {
        // Find the first selectable item in the menu
        
    }

    private void Update() {
        ItemContent.GetComponentInChildren<Button>()?.Select();
    }

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
        print("Removed : "+ item );
        items.Remove(item);
        foreach(Transform itemC in ItemContent){
            if(item.itemName.Equals(itemC.Find("ItemName").GetComponent<TMP_Text>().text)){
                Destroy(itemC.gameObject);
            }
        }
    }

    public void ListItems(){
        int i = 0;
        foreach (var item in items)
        {
            i+=1;
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName")?.GetComponent<TextMeshProUGUI>();
            var itemImage = obj.transform.Find("ItemImage")?.GetComponent<Image>();

            itemName.text = item.itemName;
            itemImage.sprite = item.itemImage;
        }

        if(i == 0){
            print("No Items");
            InventoryPanel.SetActive(false);
            character.GetComponent<SettingsMenuManager>().CloseMenu();
        }

        SetInventoryItems();
    }

    public void PlaceItem(Item item){
        foreach (GameObject obj in objects){
            if (obj.name.Equals(item.itemName)){
                obj.SetActive(true);
                mainCamera.GetComponent<GrabObject>().PickupObject(obj);
            }
            print("obj.name : "+ obj.name);
        }
        Remove(item);
        InventoryPanel.SetActive(false);
        // ;
    }

    public void SetInventoryItems(){
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i=0; i< items.Count && i< (this.space); i++){
            InventoryItems[i].AddItem(items[i]);
        }
    }
}
