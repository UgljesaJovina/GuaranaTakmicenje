using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    struct Wave
    {
        public WaveEnemy[] enemies;
    }

    [System.Serializable]
    struct WaveEnemy
    {
        public Enemy enemyType;
        public int spawnCount;
    }

    [SerializeField] EnemyStats baseStats;

    public static float statMultiplier = 0f;

    [Header("Spawn locations")]
    [SerializeField] Vector2[] positions;

    [Header("Chase targets")]
    [SerializeField] Transform gradnOwl;
    [SerializeField] Transform player;

    [Header("Wave logic")]
    [SerializeField] Wave[] waves;
    List<Enemy> spawnedEnemies;
    int currentWave = 0;
    [SerializeField] float timeBetweenWaves = 30f, currentTimeBetweenWaves = 30;
    int timeBetweenSpawnsMilis = 250;
    bool waveSpawned = false, waveKilled = false;

    void Update()
    {
        currentTimeBetweenWaves -= Time.deltaTime;

        if (currentTimeBetweenWaves <= 0 && waveKilled) SpawnWave();
    }

    public async void SpawnWave()
    {
        spawnedEnemies = new List<Enemy>();
        waveSpawned = false;
        waveKilled = false;

        while (!waveSpawned)
        {
            // grabbing the reference for the enemy to spawn
            Enemy retEnemy = RandomEnemySpawn();

            // checking if we already spawned the whole wave of enemies
            if (retEnemy == null) break;

            // grabbing the reference to the acctual enemy GameObject and subscribing to its onDeath event
            Enemy e = Instantiate(retEnemy, positions[Random.Range(0, positions.Length)], Quaternion.identity);

            e.stats = new EnemyStats(baseStats);
            e.stats.MultiplyStats(statMultiplier);
            e.player = player;
            e.grandOwl = gradnOwl;

            spawnedEnemies.Add(e);

            e.deathEvent += EnemyDeath;

            await Task.Delay(timeBetweenSpawnsMilis);
        }

        waveSpawned = true;
        currentWave++;
        statMultiplier += statMultiplier * 0.05f;
    }

    Enemy RandomEnemySpawn()
    {
        // not spawned enemies
        var enemyGroups = waves[currentWave].enemies.Where(wave => wave.spawnCount > 0).ToArray();

        if (enemyGroups.Length == 0)
        {
            waveSpawned = true;
            return null;
        }

        int rand = Random.Range(0, enemyGroups.Length);

        enemyGroups[rand].spawnCount--;

        return enemyGroups[rand].enemyType;
    }

    void EnemyDeath(Enemy caller)
    {
        spawnedEnemies.Remove(caller);
        if (spawnedEnemies.Count == 0 && waveSpawned)
        {
            waveKilled = true;
            currentTimeBetweenWaves = timeBetweenWaves;
        }
    }
}