using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {
    public GameObject TT1, TT2;
    public Animator anim1, anim2;
    // Use this for initialization
    void Start () {
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        anim1.SetTrigger("isDead");
        anim2.SetTrigger("isDead");
    }
}
