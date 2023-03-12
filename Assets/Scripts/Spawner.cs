using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;

    private float _elapsedTime = 0;

    private void Start()
    {
        if (_enemyPrefab.TryGetComponent(out Enemy enemy))
            Initialize(_enemyPrefab);

        StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointRandom = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointRandom].position);
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
