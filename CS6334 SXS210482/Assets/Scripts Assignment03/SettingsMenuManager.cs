using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class SettingsMenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    private GameObject player;
    public GameObject mainCamera;
    public GameObject XRCardboardRig;
    public GameObject VRGroup;
    public GameObject EventSystem;
    public GameObject inventory;
    public GameObject speedButton;
    public int speedCounter = 0;
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
            }
            else{
                CloseMenu();
            }
        }


    }

    public void OpenMenu()
    {
        settingsMenu.SetActive(true);
        player.GetComponent<CharacterMovement>().enabled = false;
        visible = true;
        XRCardboardRig.GetComponent<XRCardboardController>().enabled = false;
        EventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        if(EventSystem.GetComponent<XRCardboardInputModule>().enabled != false){
            EventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        }
        VRGroup.SetActive(false);
    }

    public void CloseMenu()
    {
        settingsMenu.SetActive(false);
        player.GetComponent<CharacterMovement>().enabled = true;
        visible = false;
        XRCardboardRig.GetComponent<XRCardboardController>().enabled = true;
        EventSystem.GetComponent<StandaloneInputModule>().enabled = false;
        EventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
        VRGroup.SetActive(true);
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
