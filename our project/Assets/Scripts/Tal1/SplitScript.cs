using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScript : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject ball2;
    public GameObject canvas2;
    public GameObject canvas;
    public GameObject joysticks;
    public GameObject joysticks2;

    // Start is called before the first frame update
    void Start()
    {
        //multiplayer mode
        if (PlayerPrefs.GetInt("multiplayer") == 0) 
        {
            cam2.gameObject.SetActive(true);
            ball2.SetActive(true);
            canvas2.SetActive(true);
            if(PlayerPrefs.GetInt("android") == 0)
            {
                joysticks2.SetActive(true);
                joysticks.transform.position = new Vector3(joysticks.transform.position.x, joysticks.transform.position.y + 540, 0);
                canvas.transform.Find("PauseButton").gameObject.transform.position += new Vector3(1748f, -358f, 0);
                canvas2.transform.Find("PauseButton2").gameObject.SetActive(true);
            }
            cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
            
            cam2.rect = new Rect(0, 0, 1, 0.5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
