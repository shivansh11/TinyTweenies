using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed;
    public float y;
    public int left;
    public float length;

    public GameObject gc;
    public GameObject bm;

    void Update () {

        if (gc.GetComponent<GameControl>().death == 1 || bm.GetComponent<ButtonManager>().paused == 1)
            return;

        transform.Translate((new Vector3(left, 0, 0)) * speed * Time.deltaTime);
        //transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);

        if (transform.position.x <= -length)
            transform.position = new Vector3(length, y, 0);
	}
}
