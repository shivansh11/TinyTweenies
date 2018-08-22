using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public GameObject WindmillPrefab;
    public GameObject SpikePrefab;
    public GameObject BombPrefab;
    public GameObject UFOPrefab;
    public float spawnRate = 4f;
    public float fastForward = 0f;

    private GameObject Windmill;
    private GameObject Spike;
    private GameObject Bomb;
    private GameObject UFO;
    private Vector2 obstaclePoolPosition = new Vector2(-20f, -20f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int obstacleIndex1;
    private int obstacleIndex2;

    void Start () {

    }
	
	void Update () {
        fastForward += Time.deltaTime;
        if (spawnRate > 1f && fastForward >= 6f) {
            fastForward = 0;
            SetSpawnRate();
        }

        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0f;
            obstacleIndex1 = Random.Range(0,3);
            obstacleIndex2 = Random.Range(-2, 1);

            if (obstacleIndex1 == 0 || obstacleIndex2 == -obstacleIndex1 || obstacleIndex2 == 0) {
                SpawnObstacles(obstacleIndex1, obstacleIndex2);
            }
        }
	}

    public void SpawnObstacles(int obstacleIndex1, int obstacleIndex2) {
        //Spawn upper world obstacles
        if (obstacleIndex1 == 1)
            Bomb = (GameObject)Instantiate(BombPrefab, new Vector2(spawnXPosition, 0.55f), Quaternion.identity);
        else if(obstacleIndex1 == 2)
            UFO = (GameObject)Instantiate(UFOPrefab, new Vector2(spawnXPosition, 2.65f), Quaternion.identity);

        //Spawn lower world obstacles
        if (obstacleIndex2 == -1)
            Spike = (GameObject)Instantiate(SpikePrefab, new Vector2(spawnXPosition, -0.5f), SpikePrefab.transform.rotation);
        else if (obstacleIndex2 == -2)
            Windmill = (GameObject)Instantiate(WindmillPrefab, new Vector2(spawnXPosition, -1.42f), WindmillPrefab.transform.rotation);
    }

    public void SetSpawnRate() {
        spawnRate /= 1.05f;
    }
}
