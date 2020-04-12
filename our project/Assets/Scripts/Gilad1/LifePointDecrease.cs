using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePointDecrease : MonoBehaviour
{
    private int lifePoints;
    private Vector3 startPosition;
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
    public Text finishChangedText;
    public Text finishChangedText2;
    public GameObject finalWindow;
    public GameObject finish1;
    public GameObject finish2;
    public GameObject plane;
    public void Die()
    {
        startPosition = GetComponent<InformationCenter>().startPosition;
        lifePoints = GetComponent<InformationCenter>().lifePoints;
        if(lifePoints == 1)
        {
            index = GetComponent<InformationCenter>().indexString;
            PlayerPrefs.SetInt("score" + index, GetComponent<InformationCenter>().score);
            //not multiplayer mode
            if(PlayerPrefs.GetInt("multiplayer") == 1)
            {
                SceneManager.LoadScene("HighscoreTable");
            }
            //multiplayer mode
            else
            {
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
                this.gameObject.SetActive(false);
                PlayerPrefs.SetInt("finish" + index, 1);
                //both player finished;
                if(PlayerPrefs.GetInt("finish") == 1 && PlayerPrefs.GetInt("finish2") == 1)
                {
                    cam2.gameObject.SetActive(false);
                    cam1.rect = new Rect(0, 0, 1, 1);
                    canvas2.gameObject.SetActive(false);
                    finish1.SetActive(false);
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
                        finishChangedText2.text = "Ohhh...";
                    }
                    else
                    {
                        finish1.SetActive(true);
                        finishChangedText.text = "Ohhh...";
                    }
                }
            }
        }
        else
        {
            //not multiplayer mode
            if(PlayerPrefs.GetInt("multiplayer") == 1)
            {
                plane.GetComponent<TimeTicking>().timeLeft = plane.GetComponent<TimeTicking>().timeStart;
            }
            GetComponent<InformationCenter>().lifePoints--;
            Debug.Log(GetComponent<InformationCenter>().lifePoints);
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
