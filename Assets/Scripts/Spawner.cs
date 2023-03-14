using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

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

            yield return _waitForSeconds;
        }
    }
}