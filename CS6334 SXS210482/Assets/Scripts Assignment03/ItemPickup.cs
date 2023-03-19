using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject inventoryFullText;

    public void Pickup(){
        print("In pickup");
        if (InventoryManager.instance.Add(item)){
            Destroy(gameObject);
        } else {
            inventoryFullText.SetActive(true);
            StartCoroutine(DisableText());
        }
    }

    IEnumerator DisableText(){
        yield return new WaitForSeconds(1);
        inventoryFullText.SetActive(false);
    }
}
