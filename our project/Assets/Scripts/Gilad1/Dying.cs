using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<LifePointDecrease>().Die();
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }
}
