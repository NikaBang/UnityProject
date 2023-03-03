using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerPlayer : MonoBehaviour
{
    public event UnityAction<bool> PlayerCollisionEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerCollisionEvent?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerCollisionEvent?.Invoke(false);
        }
    }
}
