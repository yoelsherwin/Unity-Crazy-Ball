using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public int lifePoints;
    public InputField playerName;
    public InputField playerName2;
    public bool multiplayer;
    public GameObject optionMenu;
    public void PlayGame()
    {
        PlayerPrefs.SetInt("volume", optionMenu.GetComponent<DropdownVolume>().volume);
        PlayerPrefs.SetInt("lifePoints", lifePoints);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetString("playerName", playerName.text);
        if(multiplayer)
        {
            Debug.Log(GetComponent<DropDown>().levelName);
            PlayerPrefs.SetInt("lifePoints2", lifePoints);
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetInt("multiplayer", 0);
            PlayerPrefs.SetInt("addHighscore", 1);
            PlayerPrefs.SetInt("finish", 0);
            PlayerPrefs.SetInt("finish2", 0);
            PlayerPrefs.SetString("playerName2", playerName2.text);
            SceneManager.LoadScene(GetComponent<DropDown>().levelName);
            
        }
        else
        {
            PlayerPrefs.SetInt("addHighscore", 1);
            PlayerPrefs.SetInt("multiplayer", 1);
            SceneManager.LoadScene("Gilad1");
        }
    }
}
