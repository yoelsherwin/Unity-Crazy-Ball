using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        if(inGame == true)
        {
            PlayerPrefs.SetInt("inGame", 0);
        }
        else
        {
            PlayerPrefs.SetInt("inGame", 1);
        }
    }
}
