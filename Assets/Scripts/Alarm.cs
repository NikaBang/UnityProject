using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _fadeSpeed;
    private float _maxVolume = 1f;
    private bool _playerInAlarm = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInAlarm = true;
            StartCoroutine(FadeIn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInAlarm = false;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        _alarm.Play();

        while (_playerInAlarm && _alarm.volume < _maxVolume)
        {
            _alarm.volume += _fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (!_playerInAlarm && _alarm.volume > 0)
        {
            _alarm.volume -= _fadeSpeed * Time.deltaTime;
            yield return null;
        }

        _alarm.Stop();
    }
}
