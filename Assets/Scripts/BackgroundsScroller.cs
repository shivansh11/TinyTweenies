using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsScroller : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    void Start () {
        speed = -speed;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
	}

	void Update () {

        if (transform.position.x < -19.2f)
            Reposition();
	}

    private void Reposition() {
        Vector2 offset = new Vector2(19.2f*2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}