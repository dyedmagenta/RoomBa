using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMovement : MonoBehaviour {
    
    //TODO: Make it react to commands not keypresses

    public float Speed = 12f;
    public float TurnSpeed = 180f;
    

    private string _movementAxisName;
    private string _turnAxisName;
    private Rigidbody _rigidbody;
    private float _movementInputValue;
    private float _turnInputValue;


    void Awake ()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start ()
    {
        _movementAxisName = "Vertical";
        _turnAxisName = "Horizontal";
    }

    void Update ()
    {
        _movementInputValue = Input.GetAxis(_movementAxisName);
        _turnInputValue = Input.GetAxis(_turnAxisName);
    }

    void FixedUpdate ()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * _movementInputValue * Speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = _turnInputValue * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }
}
