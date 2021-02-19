using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;


    //Public keyword will be removed later
    public int highScore = 0;
    public float score = 0;
    public bool playerAlive = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    void Start()
    {
        GetSavedScore();
    }

    void Update()
    {
        //This functionality is added later
        if (scoreText != null)
            scoreText.text = "" + (int)score;
    }

    void OnDisable()
    {
        SaveScore();
    }

    void GetSavedScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        //This functionality is added later
        if (highScoreText != null)
            highScoreText.text = "" + highScore;
    }

    public void SaveScore()
    {
        if (score > highScore)
            PlayerPrefs.SetInt("HighScore", (int)score);
    }

    public void AddToScore(float amount)
    {
        if (playerAlive)
            score += amount;
    }

    public void StartScoring()
    {
        playerAlive = true;
    }

    public void StopScoring()
    {
        playerAlive = false;
    }

    public void ResetScore()
    {
        score = 0;
        GetSavedScore();
    }

    // Infinite Rounds, 10 enemies per round. Random enemies are spawned each round.


}
