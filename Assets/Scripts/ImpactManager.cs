using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {
    public GameObject TT1, TT2, ActionController;
    public Animator anim1, anim2;

    public float lifetime = 5f;
    public float timeSinceLastSpawned;
    private ButtonManager bm;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
        ActionController = GameObject.Find("ActionController");
        bm = GameObject.Find("ButtonController").GetComponent<ButtonManager>();
    }


    void Update () {
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

    private void OnCollisionEnter2D(Collision2D collision){
        //gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1")
            ActionController.GetComponent<Actions>().Die("TT1");
        else if (collision.gameObject.name == "TT2")
            ActionController.GetComponent<Actions>().Die("TT2");
        else {
            gameObject.transform.position = new Vector3(12f, gameObject.transform.position.y, 0);
            gameObject.GetComponent<BackgroundsScroller>().enable = false;
            timeSinceLastSpawned = 0f;
            gameObject.SetActive(false);
        }
    }
}
