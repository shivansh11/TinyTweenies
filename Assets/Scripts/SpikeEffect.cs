using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEffect : MonoBehaviour {
    public GameObject TT2, SpikeText;

    void Start () {
        TT2 = GameObject.Find("TT2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT2")
        {
            SpikeText.GetComponent<ParticleSystem>().Play(true);
            TT2.GetComponent<Rigidbody2D>().AddForce(TT2.transform.up * 600f);
        }

    }
}

