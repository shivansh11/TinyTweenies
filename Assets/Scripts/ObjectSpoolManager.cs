using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpoolManager : MonoBehaviour {

    public GameObject[] Alien;
    public GameObject[] Bird;
    public GameObject[] Bomb;
    public GameObject[] Monkey;
    public GameObject[] Spike;
    public GameObject[] UFO;
    public GameObject[] UFO1;
    public GameObject[] Windmill;

    void Start () {
		
	}

    public void SpawnAlien() {
        if (Alien[0].transform.position.x == 12f) {
            Alien[0].SetActive(true);
            Alien[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Alien[1].SetActive(true);
            Alien[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Alien[2].SetActive(true);
            Alien[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Alien[3].SetActive(true);
            Alien[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnBird() {
        if (Bird[0].transform.position.x == 12f) {
            Bird[0].SetActive(true);
            Bird[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Bird[1].SetActive(true);
            Bird[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Bird[2].SetActive(true);
            Bird[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Bird[3].SetActive(true);
            Bird[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnBomb() {
        if (Bomb[0].transform.position.x == 12f) {
            Bomb[0].SetActive(true);
            Bomb[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Bomb[1].SetActive(true);
            Bomb[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Bomb[2].SetActive(true);
            Bomb[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Bomb[3].SetActive(true);
            Bomb[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnMonkey() {
        if (Monkey[0].transform.position.x == 12f) {
            Monkey[0].SetActive(true);
            Monkey[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Monkey[1].SetActive(true);
            Monkey[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Monkey[2].SetActive(true);
            Monkey[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Monkey[3].SetActive(true);
            Monkey[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnSpike() {
        if (Spike[0].transform.position.x == 12f) {
            Spike[0].SetActive(true);
            Spike[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Spike[1].SetActive(true);
            Spike[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Spike[2].SetActive(true);
            Spike[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Spike[3].SetActive(true);
            Spike[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    } 

    public void SpawnUFO() {
        if (UFO[0].transform.position.x == 12f) {
            UFO[0].SetActive(true);
            UFO[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            UFO[1].SetActive(true);
            UFO[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            UFO[2].SetActive(true);
            UFO[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            UFO[3].SetActive(true);
            UFO[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnUFO1() {
        if (UFO1[0].transform.position.x == 12f) {
            UFO1[0].SetActive(true);
            UFO1[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            UFO1[1].SetActive(true);
            UFO1[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            UFO1[2].SetActive(true);
            UFO1[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            UFO1[3].SetActive(true);
            UFO1[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

    public void SpawnWindmill() {
        if (Windmill[0].transform.position.x == 12f) {
            Windmill[0].SetActive(true);
            Windmill[0].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[1].transform.position.x == 12f) {
            Windmill[1].SetActive(true);
            Windmill[1].GetComponent<BackgroundsScroller>().enable = true;
        } else if (Alien[2].transform.position.x == 12f) {
            Windmill[2].SetActive(true);
            Windmill[2].GetComponent<BackgroundsScroller>().enable = true;
        } else {
            Windmill[3].SetActive(true);
            Windmill[3].GetComponent<BackgroundsScroller>().enable = true;
        }
    }

}
