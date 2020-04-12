using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Canvas canvas2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        if(PlayerPrefs.GetInt("multiplayer") == 1)
        {
            if(PlayerPrefs.GetInt("finish") == 0 && PlayerPrefs.GetInt("finish2") == 1)
            {
                canvas2.gameObject.transform.Find("PauseMenu2").gameObject.SetActive(false);
            }
            else
            {
                PauseMenuUI.SetActive(false);
            }
        }
        else
        {
            PauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if(PlayerPrefs.GetInt("multiplayer") == 0)
        {
            if(PlayerPrefs.GetInt("finish") == 0 && PlayerPrefs.GetInt("finish2") == 1)
            {
                if(canvas2.gameObject.transform.Find("PauseMenu2") != null)
                {
                    Debug.Log("pause222222222");
                    canvas2.gameObject.transform.Find("PauseMenu2").gameObject.SetActive(true);
                }
            }
            else
            {
                PauseMenuUI.SetActive(true);
            }
        }
        else
        {
            PauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!!");
        PlayerPrefs.SetInt("volume",1);
        Application.Quit();
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
