using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOUT : MonoBehaviour {

	void Start () {
        StartCoroutine(Fade());
	}

    IEnumerator Fade() {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Image>().CrossFadeAlpha(0f, 0.5f, true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}
