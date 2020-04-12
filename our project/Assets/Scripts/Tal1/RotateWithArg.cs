using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithArg : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;
    public float z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
