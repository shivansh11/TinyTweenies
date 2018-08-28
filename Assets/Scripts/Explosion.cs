using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject TT1, BoomText;

    void Start () {
        TT1 = GameObject.Find("TT1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1")
        {
            BoomText.GetComponent<ParticleSystem>().Play(true);
            TT1.GetComponent<Rigidbody2D>().AddForce(TT1.transform.up * 600f);
        }

    }
}
