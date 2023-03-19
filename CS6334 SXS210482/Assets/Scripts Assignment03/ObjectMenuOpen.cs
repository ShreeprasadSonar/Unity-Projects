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
        if(this.pointed && Input.GetKeyDown("joystick button 1")){
            ObjectMenu.GetComponent<ObjectMenuManager>().Start();
            ObjectMenu.GetComponent<ObjectMenuManager>().OpenMenu(ObjectMenu);
        }     
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
