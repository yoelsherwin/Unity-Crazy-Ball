using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorStart : MonoBehaviour
{
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
