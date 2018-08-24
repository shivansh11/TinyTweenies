﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    public GameObject TT1, TT2;
    public Animator anim1, anim2;

    public float lifetime = 5f;
    private float timeSinceLastSpawned;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
    }
	
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= lifetime)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1" || collision.gameObject.name == "TT2"){
            Destroy(gameObject);
            //and add coins to plyerprefs
        }   
    }
}
