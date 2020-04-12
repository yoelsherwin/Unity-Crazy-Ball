using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    private float x;
    float timer =  0.0f;
    float waitTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            timer = 0f;
            if(transform.localScale.x == 0)
            {
            transform.localScale = new Vector3(x, transform.localScale.y,transform.localScale.z);
            } else 
            transform.localScale = new Vector3(0f, transform.localScale.y,transform.localScale.z);
        }
    }
}
