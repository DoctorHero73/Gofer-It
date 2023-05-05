using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 10; 
    [SerializeField] private float _turnSpeed = 360;

    private InputControlls input = null;
    private Vector3 moveVector = Vector3.zero;

    private void Awake()
    {
        input = new InputControlls();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPreformed;
        input.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPreformed;
        input.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        _rb.velocity = moveVector * _speed;
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector3>();
    }

    

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector3.zero;
    }
}
