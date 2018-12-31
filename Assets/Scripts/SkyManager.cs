using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour {

    public GameObject SkyUp;
    public GameObject SkyDown;
    public GameObject StarsUp;
    public GameObject StarsDown;

    public GameObject City;
    public GameObject City1;
    public GameObject Village;
    public GameObject Village1;

    public GameObject CityClouds;
    public GameObject VillageClouds;

    //Always change the color properties through Inspector
    public Color Day;
    public Color Night;
    public Color Glow;
    public Color Unglow;

    public Color DayForeground;
    public Color NightForeground;

    public Color DayClouds;
    public Color NightClouds;

    public GameObject LeftLaser;
    public GameObject RightLaser;

    private Animator leftLaser, rightLaser;

    private int indra = 0;
    private float t = 0;

    void Start () {
        Application.targetFrameRate = -1;
        leftLaser = LeftLaser.GetComponent<Animator>();
        rightLaser = RightLaser.GetComponent<Animator>();
        SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Night);
        SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Day);
        indra = Random.Range(0, 2);
    }

	void Update () {
        if (indra == 0) {
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day, Night, t));
            City.GetComponent<SpriteRenderer>().color = Color.Lerp(DayForeground, NightForeground, t);
            City1.GetComponent<SpriteRenderer>().color = Color.Lerp(DayForeground, NightForeground, t);
            StarsUp.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, (t-0.75f) * 4);
            CityClouds.GetComponent<SpriteRenderer>().color = Color.Lerp(DayClouds, NightClouds, t * 2);


            SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night, Day, t));
            Village.GetComponent<SpriteRenderer>().color = Color.Lerp(NightForeground, DayForeground, t);
            Village1.GetComponent<SpriteRenderer>().color = Color.Lerp(NightForeground, DayForeground, t);
            StarsDown.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t * 2);
            VillageClouds.GetComponent<SpriteRenderer>().color = Color.Lerp(NightClouds, DayClouds, (t - 0.75f) * 4);

            //Laser Show
            if (t > 0.7f) {
                LeftLaser.SetActive(true);
                RightLaser.SetActive(true);
            } else {
                LeftLaser.SetActive(false);
                RightLaser.SetActive(false);
            }
        } else {
            SkyUp.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Night, Day, t));
            City.GetComponent<SpriteRenderer>().color = Color.Lerp(NightForeground, DayForeground, t);
            City1.GetComponent<SpriteRenderer>().color = Color.Lerp(NightForeground, DayForeground, t);
            StarsUp.GetComponent<SpriteRenderer>().color = Color.Lerp(Glow, Unglow, t * 2);
            CityClouds.GetComponent<SpriteRenderer>().color = Color.Lerp(NightClouds, DayClouds, (t - 0.75f) * 4);

            SkyDown.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Day, Night, t));
            Village.GetComponent<SpriteRenderer>().color = Color.Lerp(DayForeground, NightForeground, t);
            Village1.GetComponent<SpriteRenderer>().color = Color.Lerp(DayForeground, NightForeground, t);
            StarsDown.GetComponent<SpriteRenderer>().color = Color.Lerp(Unglow, Glow, (t - 0.75f) * 4);
            VillageClouds.GetComponent<SpriteRenderer>().color = Color.Lerp(DayClouds, NightClouds, t * 2);

            //Laser Show
            if (t < 0.4f) {
                LeftLaser.SetActive(true);
                RightLaser.SetActive(true);
            } else {
                LeftLaser.SetActive(false);
                RightLaser.SetActive(false);
            }
        }

        t += Time.deltaTime / 60;
        if (t >= 1.0f) {
            t = 0f;
            indra = (indra + 1) % 2;
        }
    }
}
