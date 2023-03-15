using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SettingsMenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    private GameObject player;
    public GameObject mainCamera;
    public GameObject XRCardboardRig;
    public GameObject VRGroup;
    public GameObject EventSystem;
    // Start is called before the first frame update
    private bool visible = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 3")){
            if (visible == false){
                OpenMenu();
                player.GetComponent<CharacterMovement>().enabled = false;
                visible = true;
                XRCardboardRig.GetComponent<XRCardboardController>().enabled = false;
                EventSystem.GetComponent<StandaloneInputModule>().enabled = true;
                if(EventSystem.GetComponent<XRCardboardInputModule>().enabled != false){
                    EventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
                }
                VRGroup.SetActive(false);
            }
            else{
                CloseMenu();
                player.GetComponent<CharacterMovement>().enabled = true;
                visible = false;
                XRCardboardRig.GetComponent<XRCardboardController>().enabled = true;
                EventSystem.GetComponent<StandaloneInputModule>().enabled = false;
                EventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
                VRGroup.SetActive(true);
            }
        }
    }

    public void OpenMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void Inventory(){
        print("Inventory");
    }

    public void Speed(){
        print("Speed");
    }

    public void Exit(){
        Application.Quit();
    }
}
