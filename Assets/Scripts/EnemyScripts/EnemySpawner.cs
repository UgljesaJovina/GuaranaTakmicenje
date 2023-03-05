using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    class Wave
    {
        public WaveEnemy[] enemies;
    }

    [System.Serializable]
    class WaveEnemy
    {
        public Enemy enemyType;
        public int spawnCount;
    }

    public static float statMultiplier = 0f;

    [Header("Spawn locations")]
    [SerializeField] Vector2[] positions;

    [Header("Chase targets")]
    [SerializeField] Transform grandOwl;
    [SerializeField] Transform player;

    [Header("Wave logic")]
    [SerializeField] Wave[] waves;
    [SerializeField] List<Enemy> spawnedEnemies = new List<Enemy>();
    int currentWave = 0;
    [SerializeField] float timeBetweenWaves = 30f, currentTimeBetweenWaves = 30;
    int currTimeBetweenSpawns = 250;
    [SerializeField] float maxTimeBetweenSpawns, minTimeBetweenSpawns;
    bool waveSpawned = false, waveKilled = true;

    private void Awake()
    {
        currTimeBetweenSpawns = (int)maxTimeBetweenSpawns;
    }

    void Update()
    {
        currentTimeBetweenWaves -= Time.deltaTime;

        if (currentTimeBetweenWaves <= 0 && waveKilled) SpawnWave();
    }

    public async void SpawnWave()
    {
        waveSpawned = false;
        waveKilled = false;
        currTimeBetweenSpawns = (int)Mathf.Clamp(currTimeBetweenSpawns - 10, minTimeBetweenSpawns, maxTimeBetweenSpawns);

        while (!waveSpawned)
        {
            // grabbing the reference for the enemy to spawn
            Enemy retEnemy = RandomEnemySpawn();

            // checking if we already spawned the whole wave of enemies
            if (retEnemy == null) break;

            // grabbing the reference to the acctual enemy GameObject and subscribing to its onDeath event
            Enemy e = Instantiate(retEnemy, positions[Random.Range(0, positions.Length)], Quaternion.identity);

            e.stats = new EnemyStats(e.stats);
            e.stats.MultiplyStats(statMultiplier);
            e.grandOwl = grandOwl;

            spawnedEnemies.Add(e);

            e.deathEvent += EnemyDeath;

            await Task.Delay(currTimeBetweenSpawns);
        }

        waveSpawned = true;
        currentWave++;
        statMultiplier += statMultiplier * 0.05f;
    }

    Enemy RandomEnemySpawn()
    {
        // not spawned enemies
        var enemyGroups = waves[currentWave].enemies.Where(wave => wave.spawnCount > 0).ToArray();

        if (enemyGroups.All(i => i.spawnCount == 0))
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
        PlayerScore.money += caller.enemyMoney;
        PlayerScore.score += caller.enemyScore;

        spawnedEnemies.Remove(caller);
        if (spawnedEnemies.Count == 0 && waveSpawned)
        {
            waveKilled = true;
            currentTimeBetweenWaves = timeBetweenWaves;
        }
    }

    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject != gameObject)
            return;

        foreach (var i in positions)
            Gizmos.DrawWireSphere(i, 1);
    }
}