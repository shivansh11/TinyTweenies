using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    public float fadeOutTime;

    public void Fade() {
        gameObject.SetActive(true);
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine() {
        Text text = GetComponent<Text>();
        Color originalColor = Color.white;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime) {
            text.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine() {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime) {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
