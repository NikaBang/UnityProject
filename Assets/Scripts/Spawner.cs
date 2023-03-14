using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (true)
            {
                int spawnPointRandom = Random.Range(0, _spawnPoints.Length);

                Instantiate(_enemyPrefab, _spawnPoints[spawnPointRandom]);
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}