using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour {
    public GameObject TT2, TT1, EnemyText;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT2" || collision.gameObject.name == "TT1") {
            EnemyText.GetComponent<ParticleSystem>().Play(true);
        }
    }
}
