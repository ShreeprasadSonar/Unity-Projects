using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hasPointerEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPointerEntered && (Input.GetKey("joystick button 1") || Input.GetKey("joystick button 2")))
        {
                transform.Rotate(0.3f,0,0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hasPointerEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasPointerEntered = false;
    }
}
