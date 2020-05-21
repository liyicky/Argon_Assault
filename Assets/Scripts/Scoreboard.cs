using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    int score;
    Text scoreText;

    [SerializeField] int scorePerHit = 10;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }


    public void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
