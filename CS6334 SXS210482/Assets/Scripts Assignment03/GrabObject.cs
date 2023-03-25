using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
  [Header("Pickup Settings")]
  [SerializeField] Transform holdArea;
  private GameObject heldObj;
  private Rigidbody heldObjRB;
  private GameObject player;

  [Header("Physics Parameters")]
  [SerializeField] private float pickupRange = 5.0f;
  [SerializeField] private float pickupForce  = 150.0f;

  private void Update()
  { 
    // PC Map
    // if (Input.GetButtonDown("js0") || Input.GetButtonDown("js3"))
    // Mobile Map
    // if (Input.GetButtonDown("js0") || Input.GetButtonDown("js3") || Input.GetButtonDown("js4"))
    // {
    //   if (heldObj == null)
    //   {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
    //     {
    //       PickupObject(hit.transform.gameObject);
    //     }
    //   }
    //   else
    //   {
    //     print("Held Object Non Null");
    //   }
    // }
    // PC Map
    // if(Input.GetKeyDown("joystick button 8") || Input.GetMouseButtonDown(0))
    // Mobile Map
    if(Input.GetKeyDown("joystick button 10") || Input.GetMouseButtonDown(0))
    {
      if (heldObj != null)
      {
        DropObject();
      }
    }
    if (heldObj != null)
    {
      MoveObject();
    }

  }

  void MoveObject()
  {
    if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
    {
      Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
      heldObjRB.AddForce(moveDirection * pickupForce);
    }
  }

  public void PickupObject(GameObject pickObj)
  {
    player = GameObject.FindWithTag("Player");
    player.GetComponent<SettingsMenuManager>().CloseMenu();
    if (pickObj.GetComponent<Rigidbody>())
    {
      heldObjRB = pickObj.GetComponent<Rigidbody>();
      heldObjRB.useGravity = false;
      heldObjRB.drag = 10;
      heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

      heldObjRB.transform.parent = holdArea;
      heldObj = pickObj;
    }
  }

  void DropObject()
  {
    heldObjRB.useGravity = true;
    heldObjRB.drag = 1;
    heldObjRB.constraints = RigidbodyConstraints.None;

    heldObjRB.transform.parent = null;
    heldObj = null;
  }
}