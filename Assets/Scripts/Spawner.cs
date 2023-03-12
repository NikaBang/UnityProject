using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefab);

        StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (TryGetObject(out Enemy enemy))
            {
                int spawnPointRandom = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointRandom].position);
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
