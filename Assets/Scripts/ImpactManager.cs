using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {
    public GameObject TT1, TT2, ActionController;
    public Animator anim1, anim2;

    public float lifetime = 5f;
    private float timeSinceLastSpawned;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
        ActionController = GameObject.Find("ActionController");
    }
	

	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= lifetime)
            Destroy(gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1" || collision.gameObject.name == "TT2")
            ActionController.GetComponent<Actions>().Die();
        else
            Destroy(gameObject);
    }
}
