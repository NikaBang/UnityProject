using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private TrigerLayer _trigerLayer;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private static readonly int IsGroundKey = Animator.StringToHash("is_ground");
    private static readonly int IsRunningKey = Animator.StringToHash("is_running");
    private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical_velocity");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

        if (_direction.y > 0 && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        _animator.SetBool(IsGroundKey, IsGrounded());
        _animator.SetBool(IsRunningKey, _direction.x != 0);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);

        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            _sprite.flipX = false;
        }
        else if (_direction.x < 0)
        {
            _sprite.flipX = true;
        }
    }

    private bool IsGrounded()
    {
        return _trigerLayer.IsTouchingLayer;
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }
}
