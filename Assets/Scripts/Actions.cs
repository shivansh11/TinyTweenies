using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    public TouchController tc;
    public GameObject TT1, TT2;
    public Rigidbody2D rb1, rb2;

    public Animator anim1, anim2;

    public float timeDelay = 1.25f;
    public float currentTime = 0f;

    void Start () {
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
        rb1 = TT1.GetComponent<Rigidbody2D>();
        rb2 = TT2.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
            
	}

    void FixedUpdate(){
        if (tc.SwipeUp && currentTime <= 0){
            currentTime = timeDelay;
            anim1.SetTrigger("isJump");
            anim2.SetTrigger("isJump");
            rb1.AddForce(TT1.transform.up*600f);
            rb2.AddForce(TT2.transform.up * 600f);
        }

        if (tc.SwipeDown)
        {
            anim1.SetTrigger("isSlide");
            anim2.SetTrigger("isSlide");
            rb1.AddForce(TT1.transform.up * (-450f));
            rb2.AddForce(TT2.transform.up * (-450f));
        }

        if (tc.Tap)
        {
            anim1.SetTrigger("isCombat");
            anim2.SetTrigger("isCombat");
        }

        if (currentTime > 0)
            currentTime -= Time.deltaTime;
    }
}
