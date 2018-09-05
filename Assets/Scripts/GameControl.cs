using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    private float timeSinceLastUpdated = 0f;
    public Text ScoreText;
    public Text CoinText;

    public float scoreTimer = 0f;

    private int score;
    private int coins;

    void Start () {
        Reset();
	}

    public void Reset() {
        score = 0;
        coins = 0;
        ScoreText.text = "Score : " + score;
        CoinText.text = "x " + coins;
    }

    public void SetScore() {
        score++;
        ScoreText.text = "Score : " + score;
    }

    public void SetCoins() {
        coins++;
        CoinText.text = "x " + coins;
    }

    void Update () {
        if (timeSinceLastUpdated > 20f && Time.timeScale < 2) {
            timeSinceLastUpdated = 0f;
            Time.timeScale += 0.05f;
        }

        timeSinceLastUpdated = timeSinceLastUpdated + (Time.deltaTime / Time.timeScale);

        scoreTimer += Time.deltaTime;
        if (scoreTimer > 0.1f / Time.timeScale) {
            SetScore();
            scoreTimer = 0f;
        }

    }

}
