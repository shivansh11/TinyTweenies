using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public GameObject WindmillPrefab;
    public GameObject AlienPrefab;
    public GameObject MonkeyPrefab;
    public GameObject BirdPrefab;
    public GameObject SpikePrefab;
    public GameObject BombPrefab;
    public GameObject UFOPrefab;
    public GameObject UFO1Prefab;
    public GameObject CoinPrefab;
    public float spawnRate = 4f;
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
    private float coinXPosition = 12f;
    private float coinYPosition = 12f;
    private int obstacleIndex1 = 0;
    private int obstacleIndex2 = 0;
    private int chooseUFO;
    private int chooseWindmillOrBird;
    private int chooseAnimal;

    void Start () {

    }
	
	void Update () {
        fastForward += Time.deltaTime;
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

    public void SpawnObstacles(int obstacleIndex1, int obstacleIndex2) {
        //Spawn upper world obstacles
        if (obstacleIndex1 == 1){
            Bomb = (GameObject)Instantiate(BombPrefab, new Vector2(spawnXPosition, 0.55f), Quaternion.identity);
            SpawnCoin("Bomb");
        }
        else if (obstacleIndex1 == 2){
            chooseUFO = Random.Range(0, 2);

            if (chooseUFO == 0)
                UFO = (GameObject)Instantiate(UFOPrefab, new Vector2(spawnXPosition, 2.65f), Quaternion.identity);
            else if (chooseUFO == 1)
                UFO1 = (GameObject)Instantiate(UFO1Prefab, new Vector2(spawnXPosition, 2.65f), Quaternion.identity);
            SpawnCoin("UFO");
        }

        //Spawn lower world obstacles
        if (obstacleIndex2 == -1){
            Spike = (GameObject)Instantiate(SpikePrefab, new Vector2(spawnXPosition, -0.5f), SpikePrefab.transform.rotation);
            SpawnCoin("Spike");
        }
        else if (obstacleIndex2 == -2){
            chooseWindmillOrBird = Random.Range(0, 2);

            if (chooseWindmillOrBird == 0)
                Windmill = (GameObject)Instantiate(WindmillPrefab, new Vector2(spawnXPosition, -1.42f), WindmillPrefab.transform.rotation);
            else if (chooseWindmillOrBird == 1)
                Bird = (GameObject)Instantiate(BirdPrefab, new Vector2(spawnXPosition, -1.9f), BirdPrefab.transform.rotation);
            SpawnCoin("Bird"); //Spawns coin(s) for both windmill and bird.
        }
    }

    public void SetSpawnRate() {
        spawnRate /= 1.05f;
    }

    public void RandomizeIndex() {
        obstacleIndex1 = Random.Range(0, 3);
        obstacleIndex2 = Random.Range(-2, 1);

        while (obstacleIndex1 == 0 && obstacleIndex2 == 0) {
            obstacleIndex1 = Random.Range(0, 3);
            obstacleIndex2 = Random.Range(-2, 1);
        }

        if (obstacleIndex1 == 0 || obstacleIndex2 == -obstacleIndex1 || obstacleIndex2 == 0)
            SpawnObstacles(obstacleIndex1, obstacleIndex2);
        else {
            chooseAnimal = Random.Range(0,3);

            switch (chooseAnimal) {
                case 0:
                    Alien = (GameObject)Instantiate(AlienPrefab, new Vector2(spawnXPosition, 0.17f), Quaternion.identity);
                    SpawnCoin("Alien");
                    break;

                case 1:
                    Monkey = (GameObject)Instantiate(MonkeyPrefab, new Vector2(spawnXPosition, -0.6f), MonkeyPrefab.transform.rotation);
                    SpawnCoin("Monkey");
                    break;

                case 2:
                    Alien = (GameObject)Instantiate(AlienPrefab, new Vector2(spawnXPosition, 0.17f), Quaternion.identity);
                    SpawnCoin("Alien");
                    Monkey = (GameObject)Instantiate(MonkeyPrefab, new Vector2(spawnXPosition, -0.6f), MonkeyPrefab.transform.rotation);
                    SpawnCoin("Monkey");
                    break;
            }
        }
    }

    public void SpawnCoin(string obstacleName) {
        int coinThreshold = Random.Range(0, 10);
        int numberOfCoins = 0;
        int leftOrRight = 0;

        if (coinThreshold > 6) {
            numberOfCoins = Random.Range(1, 3); //either 1 or 2 coins
            if (numberOfCoins == 1)
                leftOrRight = Random.Range(0, 2);  // ) means left, 1 means right
            else
                leftOrRight = 2; // and 2 means both

            switch (obstacleName) {
                case "UFO":
                    switch (leftOrRight) {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition -2.5f, 3f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2.5f, 3f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2.5f, 3f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2.5f, 3f), Quaternion.identity);
                            break;
                    }
                    break;

                case "Alien":
                    switch (leftOrRight)
                    {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2f, 0.7f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2f, 0.7f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2, 0.7f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2, 0.7f), Quaternion.identity);
                            break;
                    }
                    break;

                case "Bomb":
                    switch (leftOrRight)
                    {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2f, 0.7f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2f, 0.7f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2, 0.7f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2, 0.7f), Quaternion.identity);
                            break;
                    }
                    break;

                case "Spike":
                    switch (leftOrRight)
                    {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2f, -0.7f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2f, -0.7f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2, -0.7f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2, -0.7f), Quaternion.identity);
                            break;
                    }
                    break;

                case "Monkey":
                    switch (leftOrRight)
                    {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2f, -0.7f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2f, -0.7f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2, -0.7f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2, -0.7f), Quaternion.identity);
                            break;
                    }
                    break;

                case "Bird":
                    switch (leftOrRight)
                    {
                        case 0:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2.5f, -3f), Quaternion.identity);
                            break;
                        case 1:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2.5f, -3f), Quaternion.identity);
                            break;
                        case 2:
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition - 2.5f, -3f), Quaternion.identity);
                            Coin = (GameObject)Instantiate(CoinPrefab, new Vector2(coinXPosition + 2.5f, -3f), Quaternion.identity);
                            break;
                    }
                    break;
            }
        }
    }
}
