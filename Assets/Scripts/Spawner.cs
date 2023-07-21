using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _timeSpawn;

    private Coroutine _current;

    private void Start()
    {
        StartState(SpawnEnemy());
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

            yield return new WaitForSeconds(_timeSpawn);
        }
    }

    private void StartState(IEnumerator coroutine)
    {
        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(coroutine);
    }
}
