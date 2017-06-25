using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Movement and rotation Component
/// </summary>
public class RoombaEngines : MonoBehaviour {
    
    
    public enum RoombaEngineStates
    {
        Forward = 1,
        Stop = 0,
        Backward = -1
    }

    /// <summary>
    /// Forward - Roomba will move forward
    /// Stop - Romba won't move
    /// Backward - Roomba will move backward
    /// </summary>
    public RoombaEngineStates RoombaMovementState
    {
        get { return _roombaMovementState; }
        set { _roombaMovementState = value; }
    }
    private RoombaEngineStates _roombaMovementState;
    
    /// <summary>
    /// Forward - Roomba will rotate right
    /// Stop - Romba won't move
    /// Backward - Roomba will rotate left
    /// </summary>
    public RoombaEngineStates RoombaRotationState
    {
        get { return _roombaRotationState; }
        set { _roombaRotationState = value; }
    }
    private RoombaEngineStates _roombaRotationState;

    /// <summary>
    /// Movement Speed, 12 is pretty fast
    /// </summary>
    public float Speed = 12f;

    /// <summary>
    /// Turn Speed 180 is also pretty fast
    /// </summary>
    public float TurnSpeed = 180f;
    
    /// <summary>
    /// For testing you can move roomba with Keypresses
    /// </summary>
    public bool IsMovingWithKeypresses = false;

    /// <summary>
    /// Used for keypresses movement
    /// </summary>
    private string _movementAxisName;
    private string _turnAxisName;


    private Rigidbody _rigidbody;
    
    /// <summary>
    /// Values assigned depending on the engine state
    /// </summary>
    private float _movementValue;
    private float _turnValue;


    void Awake ()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start ()
    {
        _movementAxisName = "Vertical";
        _turnAxisName = "Horizontal";
    }

    /// <summary>
    /// Setting Values happens during regular updates
    /// </summary>
    void Update ()
    {
        if (IsMovingWithKeypresses)
        {
            _movementValue = Input.GetAxis(_movementAxisName);
            _turnValue = Input.GetAxis(_turnAxisName);
        }
        else
        {
            _movementValue = (int) _roombaMovementState;
            _turnValue = (int) _roombaRotationState;
        }
    }

    /// <summary>
    /// Rotation and movement happens during fixed frames because of using rigidbody
    /// </summary>
    void FixedUpdate ()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * _movementValue * Speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = _turnValue * TurnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }
}
