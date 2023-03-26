using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMenuOpen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ObjectMenu;
    private bool pointed = false;

    // Update is called once per frame
    void Update()
    {
        // PC Map
        // if(this.pointed && Input.GetKeyDown("joystick button 1"))
        // Mobile Map
        if(this.pointed && Input.GetKeyDown("joystick button 2"))
        {
            OpenMenu();
        }    
        
    }

    public void OpenMenu(){
        ObjectMenu.SetActive(true);
    }

    public void CloseMenu(){
        ObjectMenu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.pointed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.pointed = false;
    }
}
