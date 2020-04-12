using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTicking : MonoBehaviour
{
    public float timeLeft;
    public float timeStart;
    public Text timeText;
    public GameObject player;
    public Text timeText2;
    public GameObject player2;
    
    void Start()
    {
        timeLeft = timeStart;
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "TIME : " + (timeLeft).ToString("0");
        //multiplayer mode
        if(PlayerPrefs.GetInt("multiplayer") == 0)
        {
            timeText2.text = "TIME : " + (timeLeft).ToString("0");
        }
        if (timeLeft < 0)
        {
            player.GetComponent<LifePointDecrease>().Die();
            //multiplayer mode
            if(PlayerPrefs.GetInt("multiplayer") == 0)
            {
                player2.GetComponent<LifePointDecrease>().Die();
            }
        }
    }
}
