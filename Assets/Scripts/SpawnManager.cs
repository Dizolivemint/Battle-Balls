using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Runtime.InteropServices.ComVisible(true)]
[System.Serializable]
public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount = 0;
    public int waveNumber = 1;
    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private GameObject Enemy()
    {
        int randomEnemy = Mathf.RoundToInt(Random.Range(0f, 1f));
        return enemyPrefab[randomEnemy];
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        GameObject enemyToSpawn;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemyToSpawn = Enemy();
            Instantiate(enemyToSpawn, GenerateSpawnPosition(), enemyToSpawn.transform.rotation);
        }
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }
}
