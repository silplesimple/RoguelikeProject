using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovemenrt : MonoBehaviour
{
    private TopDownCharacterController _controller;
    [SerializeField] private int Speed = 10;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller= GetComponent<TopDownCharacterController>();
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * Speed;

        _rigidbody.velocity = direction;
    }


}
