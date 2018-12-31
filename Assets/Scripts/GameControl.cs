using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    private float timeSinceLastUpdated = 0f;
    public Text ScoreText;
    public int death = 0;
    
    public float scoreTimer = 0f;
    public GameObject ButtonController;

    public int score;
    private int coins;

    void Start () {
        Reset();
	}

    public void Reset() {
        death = 0;
        score = 0;
        coins = 0;
        ScoreText.text = "Score : " + score;
        Time.timeScale = 2f;
    }

    public void SetScore() {
        score++;
        ScoreText.text = "Score : " + score;
    }

    void Update () {

        if (death == 1 || ButtonController.GetComponent<ButtonManager>().paused == 1)
            return;

        if (timeSinceLastUpdated > 5f && Time.timeScale < 3) {
            timeSinceLastUpdated = 0f;
            Time.timeScale += 0.1f;
        }

        timeSinceLastUpdated = timeSinceLastUpdated + (Time.deltaTime / Time.timeScale);

        scoreTimer += Time.deltaTime;
        if (scoreTimer > 0.1f) {
            SetScore();
            scoreTimer = 0f;
        }
    }

    public void Die() {
        death = 1;
    }

}
