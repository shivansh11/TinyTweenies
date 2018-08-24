using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    private float timeSinceLastUpdated = 0f;

	void Start () {
		
	}
	
	void Update () {
        if (timeSinceLastUpdated > 20f && Time.timeScale < 2) {
            timeSinceLastUpdated = 0f;
            Time.timeScale += 0.05f;
        }

        timeSinceLastUpdated = timeSinceLastUpdated + (Time.deltaTime / Time.timeScale);
	}
}
