using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMenuManager : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject mainCamera;
    public GameObject PickupObject;
    private GameObject player;
    public GameObject XRCardboardRig;
    public GameObject VRGroup;
    public GameObject EventSystem;
    public GameObject inventory;
    
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    public void OpenMenu(GameObject receivedMenu)
    {
        controlMenu = receivedMenu;
        controlMenu.SetActive(true);
        player.GetComponent<CharacterMovement>().enabled = false;
    }

    public void CloseMenu()
    {
        player.GetComponent<CharacterMovement>().enabled = true;
        PickupObject.SetActive(false);
        controlMenu.SetActive(false);
        PickupObject.SetActive(true);
        
        
    }
    public void Grab()
    {
        PickupObject.SetActive(false);
        controlMenu.SetActive(false);
        PickupObject.SetActive(true);
        mainCamera.GetComponent<GrabObject>().PickupObject(this.PickupObject);
    }

    public void Store()
    {
        PickupObject.SetActive(false);
        controlMenu.SetActive(false);
        PickupObject.SetActive(true);
        PickupObject.GetComponent<ItemPickup>().Pickup(this.PickupObject);
    }

}
