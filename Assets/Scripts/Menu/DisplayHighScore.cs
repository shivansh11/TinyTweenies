using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

    public GameObject HighScoreText;

    void Start () {
        if (PlayerPrefs.GetInt("Score") > 0) 
            gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
	}
}
