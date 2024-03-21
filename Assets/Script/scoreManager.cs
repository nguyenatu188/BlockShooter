using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public int score = 0;
    private int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
