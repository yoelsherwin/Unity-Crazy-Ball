using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joybutton;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("android") == 0)
        {
            transform.Find("PauseButton").gameObject.SetActive(true);
            if(PlayerPrefs.GetInt("multiplayer") == 0)
            {
                Debug.Log("rotate canvas");
                transform.Find("LifeText").gameObject.transform.Rotate(0, 0, 180f);
                transform.Find("LifeText").gameObject.transform.position += new Vector3(100f, -357f, 0);
                transform.Find("ScoreText").gameObject.transform.Rotate(0, 0, 180f);
                transform.Find("ScoreText").gameObject.transform.position += new Vector3(70f, -357f, 0);
                transform.Find("TimeText").gameObject.transform.Rotate(0, 0, 180f);
                transform.Find("TimeText").gameObject.transform.position += new Vector3(0f, -357f, 0);
                transform.Find("FinishWindow").gameObject.transform.Rotate(0, 0, 180f);
                Vector3 temp = transform.Find("LifeText").gameObject.transform.position;
                transform.Find("LifeText").gameObject.transform.position = transform.Find("ScoreText").gameObject.transform.position;
                transform.Find("ScoreText").gameObject.transform.position = temp;
                joystick.transform.position += new Vector3(-1667f, 350f, 0);
                joybutton.transform.position += new Vector3(1667f, 350f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
