using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    private GameObject player;
    public GameObject mainCamera;
    public GameObject XRCardboardRig;
    public GameObject VRGroup;
    public GameObject EventSys;
    public GameObject inventory;
    public GameObject reticle;
    public Selectable resumeButton;
    public Selectable inventoryButton;
    public Selectable speedButton;
    public Selectable exitButton;
    public GameObject speedText;
    public int speedCounter = 0;
    // BaseEventData m_BaseEvent;
    // Start is called before the first frame update
    private bool visible = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // PC Map
        // if (Input.GetKeyDown("joystick button 3"))
        // Mobile Map
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (visible == false){
                OpenMenu();              
            }
            else{
                CloseMenu();
            }
        }

        // if (visible == true && Input.GetKeyDown("joystick button 10"))
        // Mobile Map
        // if (Input.GetKeyDown("joystick button 5"))
        {
            // if(resumeButton EventSystem.current.currentSelectedGameObject == resumeButton.gameObject){
            //     print("resumeButton is Highlighted");
            // }
        }

        // if (Input.GetKeyDown("joystick button 10")){
        //     GameObject selected = EventSys.current.currentSelectedGameObject;
        //     if (selected != null) {
        //         print(selected.name + " was selected.");
        //         // perform action based on the selected object
        //     }
        //     else {
        //         print("No object currently selected.");
        //     }
        // }


    }

    public void OpenMenu()
    {
        visible = true;
        settingsMenu.SetActive(true);
        VRGroup.SetActive(false);
        settingsMenu.GetComponentInChildren<Button>()?.Select();
        player.GetComponent<CharacterMovement>().enabled = false;
        XRCardboardRig.GetComponent<XRCardboardController>().enabled = false;
        EventSys.GetComponent<StandaloneInputModule>().enabled = true;
        if(EventSys.GetComponent<XRCardboardInputModule>().enabled != false){
            EventSys.GetComponent<XRCardboardInputModule>().enabled = false;
        }
        settingsMenu.GetComponentInChildren<Button>()?.Select();
    }

    public void CloseMenu()
    {
        visible = false;
        settingsMenu.SetActive(false);
        VRGroup.SetActive(true);
        player.GetComponent<CharacterMovement>().enabled = true;
        XRCardboardRig.GetComponent<XRCardboardController>().enabled = true;
        EventSys.GetComponent<StandaloneInputModule>().enabled = false;
        EventSys.GetComponent<XRCardboardInputModule>().enabled = true;
    }

    public void Inventory(){
        settingsMenu.SetActive(false);
        inventory.SetActive(true);
    }

    public void Speed(){
        if (this.speedCounter == 2){
            this.speedCounter = 0;
        }
        else{
            this.speedCounter++;
        }
        if (this.speedCounter == 0){
            speedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Speed: High";
            player.GetComponent<CharacterMovement>().speed = 20;
        }
        else if (this.speedCounter == 1){
            speedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Speed: Medium";
            player.GetComponent<CharacterMovement>().speed = 10;
        }
        else if (this.speedCounter == 2){
            speedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Speed: Low";
            player.GetComponent<CharacterMovement>().speed = 5;
        }
    }

    public void Exit(){
        Application.Quit();
    }
}
