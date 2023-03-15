using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour
{
    public GameObject controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMenu()
    {
        controlMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        controlMenu.SetActive(false);
    }

    public void Grab()
    {
        print("Grab");
    }

    public void Store()
    {
        print("Store");
    }

}
