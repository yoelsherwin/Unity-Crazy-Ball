using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSoundController : MonoBehaviour
{
    // Start is called before the first frame update
         void OnCollisionEnter (Collision collision)  //Plays Sound Whenever collision detected
    {
         if(collision.gameObject.tag == "Player")
            {
                if(PlayerPrefs.GetInt("volume") == 0)
                {
                    if(FindObjectOfType<AudioManager>() != null)
                    {
                        FindObjectOfType<AudioManager>().Play("Collision");
                        Debug.Log("collision audio");
                    }
                    else
                    {
                        Debug.Log("collision audio failed");
                    }
                }
            }
    }
}
