using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour {

    public GameObject BubbleUp, BubbleDown;
    public GameObject[] SpeechUp;
    public GameObject[] SpeechDown;

    public void Bubble(string character) {
        
        //Spawn bubble for the reverse side
        if (character == "TT1") {
            StartCoroutine(SpeakDown());
        } else {
            StartCoroutine(SpeakUp());
        }
    }

    IEnumerator SpeakUp() {
        int i = Random.Range(0, 3);
        BubbleUp.SetActive(true);
        SpeechUp[i].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BubbleUp.SetActive(false);
        SpeechUp[i].SetActive(false);
    }

    IEnumerator SpeakDown() {
        int i = Random.Range(0, 3);
        BubbleDown.SetActive(true);
        SpeechDown[i].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BubbleDown.SetActive(false);
        SpeechDown[i].SetActive(false);
    }

}
