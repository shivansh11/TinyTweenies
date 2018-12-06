using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public GameObject ButtonController;
    public GameObject ObjectSpool;

    public GameObject WindmillPrefab;
    public GameObject AlienPrefab;
    public GameObject MonkeyPrefab;
    public GameObject BirdPrefab;
    public GameObject SpikePrefab;
    public GameObject BombPrefab;
    public GameObject UFOPrefab;
    public GameObject UFO1Prefab;
    public float spawnRate;
    public float fastForward = 0f;

    private GameObject Windmill;
    private GameObject Monkey;
    private GameObject Alien;
    private GameObject Coin;
    private GameObject Bird;
    private GameObject Spike;
    private GameObject Bomb;
    private GameObject UFO;
    private GameObject UFO1;
    private Vector2 obstaclePoolPosition = new Vector2(-20f, -20f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 12f;
    private int obstacleIndex1 = 0;
    private int obstacleIndex2 = 0;
    private int chooseUFO;
    private int chooseWindmillOrBird;
    private int chooseAnimal;
	
	void Update () {
        if (gameObject.GetComponent<GameControl>().death == 1 || ButtonController.GetComponent<ButtonManager>().paused == 1)
            return;

        fastForward += Time.deltaTime;

        //fastForward is a counter. It will increase the speed of spawnrate at every x seconds till it becomes 1.5 seconds.

        if (spawnRate > 1.5f && fastForward >= 6f) {
            fastForward = 0;
            SetSpawnRate();
        }

        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0f;
            RandomizeIndex();
        }
	}

    public void SetSpawnRate() {
        spawnRate /= 1.05f;
    }

    public void RandomizeIndex() {
        SetObstacleIndex(Random.Range(0, 8));

        if (obstacleIndex1 == 0 || obstacleIndex2 == -obstacleIndex1 || obstacleIndex2 == 0)
            SpawnObstacles(obstacleIndex1, obstacleIndex2);
        else {
            chooseAnimal = Random.Range(0, 3);

            switch (chooseAnimal) {
                case 0:
                    ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnAlien();
                    break;

                case 1:
                    ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnMonkey();
                    break;

                case 2:
                    ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnAlien();
                    ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnMonkey();
                    break;
            }
        }
    }

    public void SpawnObstacles(int obstacleIndex1, int obstacleIndex2) {
        //Spawn upper world obstacles
        if (obstacleIndex1 == 1){
            ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnBomb();
        }
        else if (obstacleIndex1 == 2){
            chooseUFO = Random.Range(0, 2);

            if (chooseUFO == 0)
                ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnUFO();
            else if (chooseUFO == 1)
                ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnUFO1();
        }

        //Spawn lower world obstacles
        if (obstacleIndex2 == -1){
            ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnSpike();
        }
        else if (obstacleIndex2 == -2){
            chooseWindmillOrBird = Random.Range(0, 2);

            if (chooseWindmillOrBird == 0)
                ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnWindmill();
            else if (chooseWindmillOrBird == 1)
                ObjectSpool.GetComponent<ObjectSpoolManager>().SpawnBird();
        }
    }

    private void SetObstacleIndex(int x) {
        switch (x) {
            case 0:
                obstacleIndex1 = 0;
                obstacleIndex2 = -2;
                break;

            case 1:
                obstacleIndex1 = 2;
                obstacleIndex2 = 0;
                break;

            case 2:
                obstacleIndex1 = 1;
                obstacleIndex2 = -1;
                break;

            case 3:
                obstacleIndex1 = 1;
                obstacleIndex2 = -2;
                break;

            case 4:
                obstacleIndex1 = 2;
                obstacleIndex2 = -1;
                break;

            case 5:
                obstacleIndex1 = 0;
                obstacleIndex2 = -1;
                break;

            case 6:
                obstacleIndex1 = 1;
                obstacleIndex2 = 0;
                break;

            case 7:
                obstacleIndex1 = 2;
                obstacleIndex2 = -2;
                break;
        }
    }
}
