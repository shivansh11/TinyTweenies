using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    public TouchController tc;
    public GameObject TT1, TT2, TT1Halo, TT2Halo, BulletPrefab, SwordCollider, MC;
    public GameObject IonicShield, YogicShield, TT1Stars, TT2Stars;
    public Rigidbody2D rb1, rb2;
    private GameObject Bullet;
    public Animator anim1, anim2;
    public GameObject BubbleController;

    public float timeDelay = 1.25f;
    public float jumpTime = 0f;
    public float slideTime = 0f;
    public float combatTime = 0f;

    void Start () {
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
        rb1 = TT1.GetComponent<Rigidbody2D>();
        rb2 = TT2.GetComponent<Rigidbody2D>();
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

        if (tc.Tap && combatTime <= 0)
        {
            combatTime = 0.6f;
            anim1.SetTrigger("isCombat");
            anim2.SetTrigger("isCombat");
            StartCoroutine(SpawnBullet());
            StartCoroutine(ActivateSword());
        }

        if (jumpTime > 0)
            jumpTime -= Time.deltaTime;

        if(slideTime > 0)
            slideTime -= Time.deltaTime;

        if (combatTime > 0)
            combatTime -= Time.deltaTime;
    }

    IEnumerator SpawnBullet() {
        yield return new WaitForSeconds(0.25f);
        Bullet = (GameObject)Instantiate(BulletPrefab, new Vector2(-4f, 1.18f), Quaternion.identity);

    }

    IEnumerator ActivateSword() {
        yield return new WaitForSeconds(0.2f);
        SwordCollider.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        SwordCollider.SetActive(false);
    }

    public void Die(string character) {
        if (!IonicShield.activeSelf) {
            anim1.SetTrigger("isDead");
            anim2.SetTrigger("isDead");
            BubbleController.GetComponent<BubbleManager>().Bubble(character);
            Halo();
        }
    }

    public void Halo() {
        if (MC.GetComponent<CameraController>().isDead == 0) {
            MC.GetComponent<CameraController>().isDead = 1;
            MC.GetComponent<CameraController>().Shake();
            StartCoroutine(ActivateHalo());
        }
    }

    IEnumerator ActivateHalo() {
        yield return new WaitForSeconds(2f);
        TT1Halo.SetActive(true);
        TT2Halo.SetActive(true);
    }

    public void StarsTT1() {
        if (!IonicShield.activeSelf)
            TT1Stars.GetComponent<ParticleSystem>().Play(true);
    }

    public void StarsTT2() {
        if (!YogicShield.activeSelf)
            TT2Stars.GetComponent<ParticleSystem>().Play(true);
    }

}
