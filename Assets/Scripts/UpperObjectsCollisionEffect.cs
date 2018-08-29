using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperObjectsCollisionEffect : MonoBehaviour {
    public GameObject TT1, TT2, TT1Stars, TT2Stars;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
        TT1Stars = GameObject.Find("TT1Stars");
        TT2Stars = GameObject.Find("TT2Stars");
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1"){
            TT1Stars.GetComponent<ParticleSystem>().Play(true);
        }

        if (collision.gameObject.name == "TT2")
        {
            TT2Stars.GetComponent<ParticleSystem>().Play(true);
        }

    }
}
