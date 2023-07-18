using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _renderer;
    private float _secondsPerFrame;
    private int _currentSprite;
    private float _nextFrameTime;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time + _secondsPerFrame;
        _currentSprite = 0;        
    }

    private void Update()
    {
        if (_nextFrameTime > Time.time) return;

        if(_currentSprite >= _sprites.Length)
        {
            if (_loop)
            {
                _currentSprite = 0;
            }
            else
            {
                enabled = false;

                return;
            }
        }

        _renderer.sprite = _sprites[_currentSprite];
        _nextFrameTime += _secondsPerFrame;
        _currentSprite++;
    }
}
