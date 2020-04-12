using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Vector3 movement;
    void OnTriggerEnter(Collider collision) 
    {
//        Debug.Log("Trigger");
        if(collision.gameObject.tag == "Elevator") 
        {
  //          Debug.Log("TriggerEnter");
            collision.gameObject.GetComponent<Rigidbody>().velocity = movement;
        }
    }
}
