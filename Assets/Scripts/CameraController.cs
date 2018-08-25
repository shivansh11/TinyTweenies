using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject TT1, TT2;
    public Animator anim1, anim2, anim;

    private int isSlideShake = 0;

    void Start () {
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
        anim = gameObject.GetComponent<Animator>();
    }
	

	void Update () {
        if (isSlideShake == 0 && anim1.GetAnimatorTransitionInfo(0).IsName("TT1Jump -> TT1Slide")) {
            isSlideShake = 1;
            StartCoroutine(SlideShake());
        }
	}

    IEnumerator SlideShake() {
        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("isSlideShake");
        yield return new WaitForSeconds(0.2f);
        isSlideShake = 0;
    }
}
