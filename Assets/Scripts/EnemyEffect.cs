using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour {
    public GameObject TT2, TT1, EnemyText, Burst, ActionController, Alien;

    public Animator anim1, anim2;

    public float lifetime = 5f;
    private float timeSinceLastSpawned;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");

        ActionController = GameObject.Find("ActionController");
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= lifetime) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        if (collision.gameObject.name == "TT2" || collision.gameObject.name == "TT1") {
            EnemyText.GetComponent<ParticleSystem>().Play(true);
        }

        if (collision.gameObject.name == "TT1")
            ActionController.GetComponent<Actions>().Die("TT1");
        else if (collision.gameObject.name == "TT2")
            ActionController.GetComponent<Actions>().Die("TT2");
        else {
            Burst.GetComponent<ParticleSystem>().Play(true);
            Alien.SetActive(false);
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
