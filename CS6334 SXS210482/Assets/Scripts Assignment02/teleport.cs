using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class teleport : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject teleportTarget;
    public GameObject player;
    bool hasPointerEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPointerEntered && (Input.GetKey("joystick button 0") || Input.GetKey("joystick button 3")))
        {
            player.SetActive(false);
            player.transform.position = teleportTarget.transform.position;
            player.SetActive(true);
            Destroy(teleportTarget);        
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
