using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    //Always change the color properties through Inspector
    public Color Morning;
    public Color Day;
    public Color Evening;
    public Color Night;

    private int indra = 0;
    private float t = 0;

    void Start () {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Night);
	}

	void Update () {
        if (indra == 0) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Morning, Day, t));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Evening, Night, t));
        } else if (indra == 1) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day, Evening, t));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Night, Morning, t));
        } else if (indra == 2) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Evening, Night, t));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Morning, Day, t));
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night, Morning, t));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Day, Evening, t));
        }

        t += Time.deltaTime / 20;
        if (t >= 1.0f) {
            t = 0f;
            indra = (indra + 1) % 4;
        }
    }

}
