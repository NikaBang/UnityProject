using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _pointPatrol;
    [SerializeField] private float _speed;

    private float _threshold = 0.2f;
    private int _indexPoint = 0;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointPatrol[_indexPoint].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _pointPatrol[_indexPoint].position) < _threshold)
        {
            if (_indexPoint < _pointPatrol.Length - 1)
            {
                _indexPoint++;
            }
            else
            {
                _indexPoint = 0;
            }
        }
    }
}
