using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour {
    public GameObject TT2, TT1, EnemyText, Burst, ActionController, Alien;

    public Animator anim1, anim2;

    public AudioSource Pop;

    public float lifetime = 5f;
    public float timeSinceLastSpawned;
    private ButtonManager bm;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");

        ActionController = GameObject.Find("ActionController");
        anim1 = TT1.GetComponent<Animator>();
        anim2 = TT2.GetComponent<Animator>();
        bm = GameObject.Find("ButtonController").GetComponent<ButtonManager>();
    }

    void Update() {
        if (bm.paused == 1)
            return;

        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= lifetime) {
            gameObject.transform.position = new Vector3(12f, gameObject.transform.position.y, 0);
            gameObject.GetComponent<BackgroundsScroller>().enable = false;
            timeSinceLastSpawned = 0f;
            gameObject.SetActive(false);
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
            ActionController.GetComponent<Actions>().PopIt();
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.position = new Vector3(12f, gameObject.transform.position.y, 0);
        gameObject.GetComponent<BackgroundsScroller>().enable = false;
        Alien.SetActive(true);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        timeSinceLastSpawned = 0f;
        gameObject.SetActive(false);
    }
}
