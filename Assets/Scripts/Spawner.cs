using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _TimeSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject prefab = Instantiate(_objectPrefab, transform.position, Quaternion.identity);

            while (prefab != null)
            {
                yield return null;
            }

            yield return new WaitForSeconds(_TimeSpawn);
        }
    }
}
