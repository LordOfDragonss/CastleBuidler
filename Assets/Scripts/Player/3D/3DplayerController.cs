using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] CameraController CameraController;

    internal Vector3 velocity;

    public event Action OnBeforeMove;
    public CharacterController characterController;
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;
    NavMeshAgent navMeshAgent;

    [Serializable]
    public enum MovementControl
    {
        Character,
        Camera
    }
    public MovementControl movementControl;
    private MovementControl previousControl;
    public static PlayerController instance;

    [SerializeField] GameObject freelookCamera;
    [SerializeField] GameObject followCamera;

    public float movementSpeed = 5f;
    public float acceleration = 20f;
    public float mass = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        instance = this;
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveAction = playerInput.actions["move"];
    }

    private void Update()
    {
        if (movementControl != previousControl)
        {
            previousControl = movementControl;
            UpdateControlMode();
        }

        if (movementControl == MovementControl.Character)
        {
            MovementCharacter();
        }
        else if (movementControl == MovementControl.Camera)
        {
            FollowMouseMarker();
        }
    }

    private void UpdateControlMode()
    {
        if (movementControl == MovementControl.Character)
        {
            CameraController.isInControlOfCamera = false;
            navMeshAgent.enabled = false;
            freelookCamera.SetActive(false);
            followCamera.SetActive(true);
        }
        if (movementControl == MovementControl.Camera)
        {
            CameraController.isInControlOfCamera = true;
            navMeshAgent.enabled = true;
            navMeshAgent.speed = movementSpeed;
            freelookCamera.SetActive(true);
            followCamera.SetActive(false);
        }
    }

    public void MovementCharacter()
    {
        UpdateGravity();
        UpdateMovement();
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = characterController.isGrounded ? -1f : velocity.y + gravity.y;
    }

    //void UpdateMovement()
    //{
    //    OnBeforeMove?.Invoke();


    //    var moveInput = moveAction.ReadValue<Vector2>();

    //    var input = new Vector3();
    //    input += transform.forward * moveInput.y;
    //    input += transform.right * moveInput.x;
    //    input = Vector3.ClampMagnitude(input, 1f);
    //    input *= movementSpeed;

    //    var factor = acceleration * Time.deltaTime;
    //    velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
    //    velocity.z = Mathf.Lerp(velocity.z, input.z, factor);


    //    Vector3 forward = followCamera.transform.forward;
    //    Vector3 right = followCamera.transform.right;

    //    forward.y = 0;
    //    right.y = 0;
    //    forward.Normalize();
    //    right.Normalize();

    //    Vector3 moveDirection = forward * input.y + right * input.x;
    //    characterController.Move(moveDirection * movementSpeed * Time.deltaTime);

    //    if (moveDirection.sqrMagnitude > 0.001f)
    //    {
    //        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
    //    }

    //    characterController.Move(velocity * Time.deltaTime);
    //}
    void UpdateMovement()
    {
        OnBeforeMove?.Invoke();

        // Read input
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Get camera forward/right but ignore vertical components
        Vector3 camForward = followCamera.transform.forward;
        Vector3 camRight = followCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Get move direction relative to camera
        Vector3 moveDirection = camForward * moveInput.y + camRight * moveInput.x;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        // Rotate player to face same direction as camera (yaw only)
        if (moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // Smooth acceleration
        Vector3 targetVelocity = transform.forward * moveInput.magnitude * movementSpeed;
        velocity.x = Mathf.Lerp(velocity.x, targetVelocity.x, acceleration * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, targetVelocity.z, acceleration * Time.deltaTime);

        // Apply movement once
        characterController.Move(velocity * Time.deltaTime);
    }

    public void FollowMouseMarker()
    {
        if (CameraController.marker != null)
            navMeshAgent.SetDestination(CameraController.marker.transform.position);
    }


}
