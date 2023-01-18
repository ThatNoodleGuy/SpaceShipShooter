using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO currentWave;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                                           currentWave.GetStartingWaypoint().position,
                                           Quaternion.identity,
                                           transform);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}