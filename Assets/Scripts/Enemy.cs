using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
