using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    float x = 0f;
    float y = 0f;

    const int MIN_Y = -4;
    const int MAX_Y = 4;
    const int MIN_X = -9;
    const int MAX_X = 9;

    const int ENEMY_LIMIT = 1;
    const float DISTANCE_BETWEEN_ENEMIES = 2;

    public GameObject enemyPrefab;

    List<GameObject> spawnedEnemies = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnedEnemies.Count < ENEMY_LIMIT) CreateEnemy();
    }

    void CreateEnemy()
    {
        x = -10f;
        y = UnityEngine.Random.Range(MIN_Y, MAX_Y);

        Spawn(x, y);
    }

    void Spawn(float x, float y)
    {
        GameObject spawned = GameObject.Instantiate(enemyPrefab);
        spawned.transform.parent = transform;
        spawned.transform.position = new Vector3(x, y, 0);
        spawnedEnemies.Add(spawned);
    }
}
