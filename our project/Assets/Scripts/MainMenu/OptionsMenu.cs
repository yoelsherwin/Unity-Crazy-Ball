using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void ClearTable()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighscoreTable.Highscores highscores = JsonUtility.FromJson<HighscoreTable.Highscores>(jsonString);

        highscores.highscoreEntryList.Clear();

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void HighscoresTable()
    {
        PlayerPrefs.SetInt("addHighscore", 0);
        SceneManager.LoadScene("HighscoreTable");
    }
}
