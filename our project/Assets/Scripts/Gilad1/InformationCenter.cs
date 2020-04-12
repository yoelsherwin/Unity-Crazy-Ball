using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationCenter : MonoBehaviour
{
    public int score;
    public int lifePoints;
    public string indexString;
    public Text scoreText;
    public Text lifeText;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score" + indexString, 0);
        lifePoints = PlayerPrefs.GetInt("lifePoints" + indexString, 3);
        Debug.Log(lifePoints);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + score.ToString();
        lifeText.text = "LIFE : " + lifePoints.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("score" + indexString, score);
        PlayerPrefs.SetInt("lifePoints" + indexString, lifePoints);
        PlayerPrefs.SetString("playerName" + indexString, PlayerPrefs.GetString("playerName" + indexString, ""));
    }
}
