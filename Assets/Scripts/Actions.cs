using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    public TouchController tc;
    public GameObject TT1, TT2, BulletPrefab;
    public Rigidbody2D rb1, rb2;
    private GameObject Bullet;
    public Animator anim1, anim2;

    public float timeDelay = 1.25f;
    public float jumpTime = 0f;
    public float slideTime = 0f;

    void Start () {
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
        rb1 = TT1.GetComponent<Rigidbody2D>();
        rb2 = TT2.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
            
	}

    void FixedUpdate(){
        if (tc.SwipeUp && jumpTime <= 0){
            jumpTime = timeDelay;
            anim1.SetTrigger("isJump");
            anim2.SetTrigger("isJump");
            rb1.AddForce(TT1.transform.up*600f);
            rb2.AddForce(TT2.transform.up * 600f);
        }

        if (tc.SwipeDown && slideTime <= 0)
        {
            slideTime = timeDelay;
            anim1.SetTrigger("isSlide");
            anim2.SetTrigger("isSlide");
            rb1.AddForce(TT1.transform.up * (-450f));
            rb2.AddForce(TT2.transform.up * (-450f));
        }

        if (tc.Tap)
        {
            anim1.SetTrigger("isCombat");
            anim2.SetTrigger("isCombat");
            StartCoroutine(SpawnBullet());
        }

        if (jumpTime > 0)
            jumpTime -= Time.deltaTime;

        if(slideTime > 0)
            slideTime -= Time.deltaTime;
    }

    IEnumerator SpawnBullet() {
        yield return new WaitForSeconds(0.1f);
        Bullet = (GameObject)Instantiate(BulletPrefab, new Vector2(-4f, 1.18f), Quaternion.identity);

    }
}
