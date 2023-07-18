using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private Player _player;

    private InputPlayer _inputPlayer;

    private void Awake()
    {
        _inputPlayer = new InputPlayer();

        _inputPlayer.Player.HorizontalMovement.performed += OnHorizontalMovement;
        _inputPlayer.Player.HorizontalMovement.canceled += OnHorizontalMovement;
    }

    private void OnEnable()
    {
        _inputPlayer.Enable();

    }

    private void OnHorizontalMovement(InputAction.CallbackContext context)
    {
            var direction = context.ReadValue<Vector2>();

            _player.Move(direction);
    }
}
