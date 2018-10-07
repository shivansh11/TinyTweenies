using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour {

    public GameObject SkyUp;
    public GameObject SkyDown;

    //Always change the color properties through Inspector
    public Color Day;
    public Color Night;
    public Color Day1;
    public Color Night1;

    public Color Day2;
    public Color Night2;
    public Color Day3;
    public Color Night3;

    private int indra = 0;
    private float t = 0;

    void Start () {
        SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Night);
        SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Day);
        indra = Random.Range(0, 2);
    }

	void Update () {
        if (indra == 0) {
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day, Night, t));
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Day1, Night1, t));

            SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night2, Day2, t));
            SkyDown.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Night3, Day3, t));
        } else {
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night, Day, t));
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Night1, Day1, t));

            SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day2, Night2, t));
            SkyDown.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Day3, Night3, t));
        }

        t += Time.deltaTime / 60;
        if (t >= 1.0f) {
            t = 0f;
            indra = (indra + 1) % 2;
        }
    }
}
