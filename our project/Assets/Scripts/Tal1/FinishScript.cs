using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject timerHolder;
    public Camera cam1;
    public Camera cam2;
    public Canvas canvas2;
    public GameObject canvas1;
    private string index;
    private string name1;
    private string name2;
    private int score1;
    private int score2;
    public Text ChangedText;
    public GameObject finalWindow;
    public GameObject finish1;
    public GameObject finish2;
    public Text finishChangedText;
    public Text finishChangedText2;

    void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<InformationCenter>().score += (int)timerHolder.gameObject.GetComponent<TimeTicking>().timeLeft * 10;
            collision.gameObject.GetComponent<InformationCenter>().score += 200;
            //not multiplayer mode
            if(PlayerPrefs.GetInt("multiplayer") == 1)
            {
                collision.gameObject.GetComponent<InformationCenter>().lifePoints++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            //multiplayer mode
            else
            {
                index = collision.gameObject.GetComponent<InformationCenter>().indexString;
                PlayerPrefs.SetInt("score" + index, collision.gameObject.GetComponent<InformationCenter>().score);
                collision.gameObject.SetActive(false);
                 if(index == "2")
                {
                    canvas2.gameObject.transform.Find("LifeText2").gameObject.SetActive(false);
                    canvas2.gameObject.transform.Find("ScoreText2").gameObject.SetActive(false);
                    canvas2.gameObject.transform.Find("TimeText2").gameObject.SetActive(false);
                    canvas2.gameObject.transform.Find("Joysticks2").gameObject.SetActive(false);
                    canvas2.gameObject.transform.Find("PauseButton2").gameObject.SetActive(false);
                }
                else
                {
                    canvas1.transform.Find("LifeText").gameObject.SetActive(false);
                    canvas1.transform.Find("ScoreText").gameObject.SetActive(false);
                    canvas1.transform.Find("TimeText").gameObject.SetActive(false);
                    canvas1.transform.Find("Joysticks").gameObject.SetActive(false);
                    canvas1.transform.Find("PauseButton").gameObject.SetActive(false);
                }
                PlayerPrefs.SetInt("finish" + index, 1);
                //both player finished;
                if(PlayerPrefs.GetInt("finish") == 1 && PlayerPrefs.GetInt("finish2") == 1)
                {
                    cam2.gameObject.SetActive(false);
                    cam1.rect = new Rect(0, 0, 1, 1);
                    canvas2.gameObject.SetActive(false);
                    finalWindow.SetActive(true);
                    name1 = PlayerPrefs.GetString("playerName");
                    name2 = PlayerPrefs.GetString("playerName2");
                    score1 = PlayerPrefs.GetInt("score");
                    score2 = PlayerPrefs.GetInt("score2");
                    ChangedText.text = "It's a win for ";
                    if(score1 > score2)
                    {
                        ChangedText.text += name1;
                    }
                    else
                    {
                        if(score1 < score2)
                        {
                            ChangedText.text += name2;
                        }
                        else
                        {
                            ChangedText.text = "It's a tie";
                        }
                    }
                    ChangedText.text += ".\n";
                    ChangedText.text += name1 + "'s score : " + score1 + "\n";
                    ChangedText.text += name2 + "'s score : " + score2;
                }
                else
                {
                    if(index == "2")
                    {
                        canvas2.renderMode = RenderMode.ScreenSpaceOverlay;
                        Debug.Log("change render");
                        finish2.SetActive(true);
                        finishChangedText2.text = "Congratulations!";
                    }
                    else
                    {
                        finish1.SetActive(true);
                        finishChangedText.text = "Congratulations!";
                    }
                }
            }
        }
    }
}
