using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private int baseEnemies = 3;
    [SerializeField] private float enemiesPerSecond = 1f;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(enemyDestroyed);
    }

    private void enemyDestroyed()
    {
        Debug.Log("enemy berkurang");
        enemiesAlive--;
    }

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = GetRandomEnemyPrefab();
        if (prefabToSpawn == null)
        {
            Debug.LogWarning("No valid enemy prefab available for spawning.");
            return;
        }

        Transform nextWaypoint = waypoints.GetNextWaypoint(null);
        Vector3 spawnPosition = nextWaypoint.position;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomEnemyPrefab()
    {
        List<GameObject> validPrefabs = new List<GameObject>();
        foreach (GameObject prefab in enemyPrefabs)
        {
            if (prefab != null && !prefab.CompareTag("Manager"))
            {
                validPrefabs.Add(prefab);
            }
        }

        if (validPrefabs.Count > 0)
        {
            return validPrefabs[Random.Range(0, validPrefabs.Count)];
        }

        return null; // No valid enemy prefabs available
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}