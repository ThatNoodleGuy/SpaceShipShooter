using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;

    private WaveConfigSO currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    private IEnumerator SpawnEnemyWaves()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                                               currentWave.GetStartingWaypoint().position,
                                               Quaternion.identity,
                                               transform);

                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}