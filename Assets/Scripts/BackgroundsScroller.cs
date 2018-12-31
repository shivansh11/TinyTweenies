using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsScroller : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;
    private GameControl gc;
    private ButtonManager bm;

    public bool enable = false;

    void Start () {
        speed = -speed;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        bm = GameObject.Find("ButtonController").GetComponent<ButtonManager>();
    }

    void FixedUpdate () {
        if (gc.death == 1) {
            rb2d.velocity = new Vector2(0, 0);
            return;
        }

        if (bm.paused == 1) {
            rb2d.velocity = new Vector2(0, 0);
            return;
        } else if (enable == true) {
            rb2d.velocity = new Vector2(speed, 0);
        } else {
            rb2d.velocity = new Vector2(0, 0);
        }

        if (transform.position.x < -19.2f)
            Reposition();
	}

    private void Reposition() {
        gameObject.transform.position = new Vector3(12f, gameObject.transform.position.y, 0);
        enable = false;
        gameObject.GetComponent<ImpactManager>().timeSinceLastSpawned = 0f;
        gameObject.SetActive(false);
    }
}