using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public bool WASDControl;
    public bool MouseControl;

    [SerializeField] CameraController CameraController;

    internal Vector3 velocity;

    public event Action OnBeforeMove;
    public CharacterController characterController;
    PlayerInput playerInput;
    InputAction moveAction;
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject freelookCamera;
    [SerializeField] GameObject followCamera;

    public float movementSpeed = 5f;
    public float acceleration = 20f;
    public float mass = 1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveAction = playerInput.actions["move"];
    }

    private void Update()
    {
        if (WASDControl)
        {
            freelookCamera.SetActive(false);
            followCamera.SetActive(true);
            MovementWASD();
            MouseControl = false;
        }
        if (MouseControl)
        {
            navMeshAgent.speed = movementSpeed;
            freelookCamera.SetActive(true);
            followCamera.SetActive(false);
            FollowMouseMarker();
            WASDControl = false;
        }
    }

    public void MovementWASD()
    {
        UpdateGravity();
        UpdateMovement();
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = characterController.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void UpdateMovement()
    {
        OnBeforeMove?.Invoke();

        var moveInput = moveAction.ReadValue<Vector2>();

        var input = new Vector3();
        input += transform.forward * moveInput.y;
        input += transform.right * moveInput.x;
        input = Vector3.ClampMagnitude(input, 1f);
        input *= movementSpeed;

        var factor = acceleration * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
        velocity.z = Mathf.Lerp(velocity.z, input.z, factor);


        characterController.Move(velocity * Time.deltaTime);
    }

    public void FollowMouseMarker()
    {
        if (CameraController.marker != null)
            navMeshAgent.SetDestination(CameraController.marker.transform.position);
    }


}
