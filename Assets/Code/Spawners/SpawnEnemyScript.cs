using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GraveTier
{
    Tombstone,
    Casket,
    Crypt
}

public class SpawnEnemyScript : MonoBehaviour
{
    [Header("Spawn Parameters")]
    public GraveTier graveTier;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    private float spawnRate;
    private int spawnSeed;
    private bool spawnOnCD;

    void Start()
    {
        GenerateSpawnValues();
        spawnOnCD = false;
    }

    void Update()
    {
        //spawn cycle
        if (!spawnOnCD)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private void GenerateSpawnValues()
    {
        //When generating seeds, lower is higher. A seed that is closer to 1 means that the spawn
        //rate is closer to 1/second.


        switch (graveTier)
        {
            case GraveTier.Tombstone:
                spawnSeed = Random.Range(35, 51);
                break;

            case GraveTier.Casket:
                spawnSeed = Random.Range(15, 51);
                break;

            case GraveTier.Crypt:
                spawnSeed = Random.Range(1, 51);
                break;
        }

        spawnRate = 51 - spawnSeed;
        Debug.Log("Current SpawnRate: " + spawnRate);
    }

    private IEnumerator SpawnEnemy()
    {
        spawnOnCD = true;
        yield return new WaitForSeconds(spawnRate);

        int enemyInt = Random.Range(1, spawnSeed);
        if(enemyInt >= 30)
        {
            Instantiate(enemyPrefabs[0], transform.position, new Quaternion());
        } else 
        if(enemyInt >= 10)
        {
            Instantiate(enemyPrefabs[1], transform.position, new Quaternion());
        }
        else
        {
            Instantiate(enemyPrefabs[2], transform.position, new Quaternion());
        }

        spawnOnCD = false;
    }
}
