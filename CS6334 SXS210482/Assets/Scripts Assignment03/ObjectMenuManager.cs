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

    // Update is called once per frame
    void Update()
    {  

    }

    public void OpenMenu(GameObject receivedMenu)
    {
        controlMenu = receivedMenu;
        controlMenu.SetActive(true);
        player.GetComponent<CharacterMovement>().enabled = false;
    }

    public void CloseMenu()
    {
        print("Close Menu");
        controlMenu.SetActive(false);
        player.GetComponent<CharacterMovement>().enabled = true;
        
    }
    public void Grab()
    {
        controlMenu.gameObject.SetActive(false);
        mainCamera.GetComponent<GrabObject>().PickupObject(this.PickupObject);
    }

    public void Store()
    {
        controlMenu.gameObject.SetActive(false);
        PickupObject.GetComponent<ItemPickup>().Pickup(this.PickupObject);
    }

}
