using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private TrigerPlayer _trigerPlayer;
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutineVolumeController;

    private const float _maxVolume = 1f;
    private const float _minVolume = 0f;
    private bool _loopCycleCoroutineChangeVolume;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;

        _trigerPlayer.PlayerCollided += Play;
    }

    private void OnDisable()
    {
        _trigerPlayer.PlayerCollided -= Play;
    }

    private void Play(bool inCollision)
    {
        if (inCollision == true)
        {
            SwitchAudio(Selector.On);
            RestartCoroutineChangeVolume(_maxVolume);
        }
        else
        {
            RestartCoroutineChangeVolume(_minVolume);
        }
    }

    private void RestartCoroutineChangeVolume(float targetVolume)
    {
        if (_coroutineVolumeController != null)
        {
            StopCoroutine(_coroutineVolumeController);
        }

        _coroutineVolumeController = StartCoroutine(AdjustVolume(targetVolume));
    }

    private IEnumerator AdjustVolume(float target)
    {
        float faultVolume = 0.01f;

        while (_loopCycleCoroutineChangeVolume == true)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_alarm.volume < faultVolume)
        {
            _alarm.Stop();
        }
    }

    private void SwitchAudio(Selector selector)
    {
        if (selector == Selector.On)
        {
            _audioSource.Play();
            _audioSource.loop = true;

            _loopCycleCoroutineChangeVolume = true;
        }
        else if (selector == Selector.Off)
        {
            _audioSource.Stop();
            _audioSource.loop = false;

            _loopCycleCoroutineChangeVolume = false;
        }
    }

    private enum Selector
    {
        On,
        Off
    }
}
