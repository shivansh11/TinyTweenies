using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    public GameObject City;
    public GameObject City1;
    public GameObject CityStars;
    public GameObject Medieval;
    public GameObject Medieval1;
    public GameObject MedievalStars;
    public GameObject Light1;
    public GameObject Light2;

    //Always change the color properties through Inspector
    public Color Morning;
    public Color Day;
    public Color Evening;
    public Color Night;
    public Color Blue;
    public Color Black;
    public Color Glow;
    public Color Unglow;

    private int indra = 0;
    private float t = 0;

    private Animator lightAnim1, lightAnim2;

    void Start () {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Night);
        indra = Random.Range(0, 4);
        lightAnim1 = Light1.GetComponent<Animator>();
        lightAnim2 = Light2.GetComponent<Animator>();
    }

	void Update () {
        if (indra == 0) { 
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Morning, Day, t));
            Medieval.GetComponent<SpriteRenderer>().color = Color.Lerp(Black, Blue, t);
            Medieval1.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, t);
            MedievalStars.GetComponent<SpriteRenderer>().color = Unglow;

            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Evening, Night, t));
            City.GetComponent<SpriteRenderer>().color = Color.Lerp(Blue, Black, t);
            City1.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t);
            CityStars.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, t);
        } else if (indra == 1) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day, Evening, t));
            Medieval.GetComponent<SpriteRenderer>().color = Blue;
            Medieval1.GetComponent<SpriteRenderer>().color = Glow;
            MedievalStars.GetComponent<SpriteRenderer>().color = Unglow;

            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Night, Morning, t));
            City.GetComponent<SpriteRenderer>().color = Black;
            City1.GetComponent<SpriteRenderer>().color = Unglow;
            CityStars.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t);
            lightAnim1.SetBool("Activate", true);
            lightAnim2.SetBool("Activate", true);
        } else if (indra == 2) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Evening, Night, t));
            Medieval.GetComponent<SpriteRenderer>().color = Color.Lerp(Blue, Black, t);
            Medieval1.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t);
            MedievalStars.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, t);

            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Morning, Day, t));
            City.GetComponent<SpriteRenderer>().color = Color.Lerp(Black, Blue, t);
            City1.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, t);
            CityStars.GetComponent<SpriteRenderer>().color = Unglow;
            lightAnim1.SetBool("Activate", false);
            lightAnim2.SetBool("Activate", false);
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night, Morning, t));
            Medieval.GetComponent<SpriteRenderer>().color = Black;
            Medieval1.GetComponent<SpriteRenderer>().color = Unglow;
            MedievalStars.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t);

            gameObject.GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(Day, Evening, t));
            City.GetComponent<SpriteRenderer>().color = Blue;
            City1.GetComponent<SpriteRenderer>().color = Glow;
            CityStars.GetComponent<SpriteRenderer>().color = Unglow;
        }

        t += Time.deltaTime / 20;
        if (t >= 1.0f) {
            t = 0f;
            indra = (indra + 1) % 4;
        }
    }

}
