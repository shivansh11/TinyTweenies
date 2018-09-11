using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour {

    public GameObject IonicShield, YogicShield;
    public Color A = new Color(1, 1, 1, 0);
    public Color B = new Color(1, 1, 1, 1);

    public void EnableShields() {
        if (!IonicShield.activeSelf) { 
            IonicShield.SetActive(true);
            YogicShield.SetActive(true);
            StartCoroutine(FadeShieldIn());
            StartCoroutine(DisableShields());
        }
    }

    IEnumerator FadeShieldIn() {
        for (float t = 0.0f; t < 1f; t += (Time.deltaTime * 3)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(0 , 1, t));
            IonicShield.GetComponent<SpriteRenderer>().color = newColor;
            YogicShield.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }

    IEnumerator DisableShields() {
        yield return new WaitForSeconds(10f);
        StartCoroutine(FadeShieldOut());
    }

    IEnumerator FadeShieldOut() {
        for (float t = 0.0f; t < 1f; t += (Time.deltaTime * 3)) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            IonicShield.GetComponent<SpriteRenderer>().color = newColor;
            YogicShield.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
        IonicShield.SetActive(false);
        YogicShield.SetActive(false);
    }
}
