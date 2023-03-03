using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private TrigerPlayer TrigerPlayer;
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _fadeSpeed;

    private const float _maxVolume = 1f;
    private const float _minVolume = 0f;
    private bool _playerInAlarm = false;

    private void OnEnable()
    {
        TrigerPlayer.PlayerCollisionEvent += PlayAlarm;
    }

    private void OnDisable()
    {
        TrigerPlayer.PlayerCollisionEvent += PlayAlarm;
    }

    private void PlayAlarm(bool inCollision)
    {
        if (inCollision == true)
        {
            _alarm.volume = _minVolume;
            _alarm.loop = true;
            _playerInAlarm = true;

            StartCoroutine(AdjustVolume(_maxVolume));
        }
        else
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

            if (cheñkCollision != _playerInAlarm)
                yield break;

            yield return null;
        }

        if (_alarm.volume < faultVolume)
        {
            _alarm.Stop();
        }
    }
}
