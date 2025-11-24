using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterContrellerExamen : MonoBehaviour
{

    //Raycast y Character Controller
    //Camara, Animaciones, Movimiento

    //Componentes
    Animator _animator;
    CharacterController _controller;

    //Inputs
    InputAction _jumpAction;
    InputAction _moveAction;
    Vector2 _moveValue;

    //Movement
    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private float _jumpHeight = 2;

    [SerializeField] private float _gravity = -9.81f;

    //Ground
    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private float _sensorRadius;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private Vector3 playerGravity;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        _jumpAction = InputSystem.actions["Jump"];
        _moveAction = InputSystem.actions["Move"];
    }

    void Update()
    {
        _moveValue = _moveAction.ReadValue<Vector2>();

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        } 
        
        Movement();

        Gravity();
    }

    void Movement()
    {
        Vector3 moveDirection = new Vector3(_moveValue.x, 0, _moveValue.y);

        _controller.Move(moveDirection* _movementSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer);
    }

    void Jump()
    {
        playerGravity.y = Mathf.Sqrt(_jumpHeight * _gravity * -2);
        _controller.Move(playerGravity * Time.deltaTime);
    }

    void Gravity()
    {
        if(!IsGrounded())
        {
            playerGravity.y += _gravity * Time.deltaTime;
        }
        else if(IsGrounded() && playerGravity.y < 0)
        {
            playerGravity.y = -2;
        }

        _controller.Move(playerGravity * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_sensorPosition.position, _sensorRadius);
    }
}
