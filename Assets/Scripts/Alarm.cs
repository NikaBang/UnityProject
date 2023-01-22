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
    private float _minVolume = 0f;
    private bool _playerInAlarm = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerInAlarm = true;
            StartCoroutine(AdjustVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerInAlarm = false;
            StartCoroutine(AdjustVolume(_minVolume));
        }
    }

    private IEnumerator AdjustVolume(float target)
    {
        float faultVolume = 0.01f;
        bool cheñkCollision = _playerInAlarm;

        if (_playerInAlarm == true) 
        {
            _alarm.Play();
        }

        while (Mathf.Abs(_alarm.volume - target) > faultVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _fadeSpeed * Time.deltaTime);

            if(cheñkCollision != _playerInAlarm)
                yield break;

            yield return null;
        }

        if (_alarm.volume < faultVolume) 
        {
            _alarm.Stop();
        }
    }
}
