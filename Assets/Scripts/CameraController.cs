using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class CameraController : MonoBehaviour
{

    internal Vector3 velocity;
    internal Vector3 look;

    [SerializeField] GameObject markerPrefab;
    public GameObject marker;

    public static bool isInControlOfCamera;

    public event Action OnBeforeMove;
    public CharacterController characterController;
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;
    InputAction crouchAction;
    InputAction selectAction;

    public float movementSpeed = 5f;
    public float acceleration = 20f;

    public float mouseSensitivity = 0.5f;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];
        jumpAction = playerInput.actions["jump"];
        crouchAction = playerInput.actions["sprint"];
        selectAction = playerInput.actions["attack"];

    }
    private void Update()
    {
        if (isInControlOfCamera)
        {
            UpdateMovement();
            UpdateLook();
            UpdateFly();
            CheckForMouseClick();
        }
    }

    public static void ToggleCameraControl()
    {
        if(PlayerController.instance.movementControl == PlayerController.MovementControl.Camera)
        {
            isInControlOfCamera = !isInControlOfCamera;
        }
    }

    #region Movement
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

    void UpdateLook()
    {
        var lookInput = lookAction.ReadValue<Vector2>();
        look.x += lookInput.x * mouseSensitivity;
        look.y += lookInput.y * mouseSensitivity;


        look.y = Mathf.Clamp(look.y, -89f, 89f);


        transform.localRotation = Quaternion.Euler(-look.y, look.x, 0);
    }

    void UpdateFly()
    {
        var upInput = jumpAction.ReadValue<float>();
        var downInput = crouchAction.ReadValue<float>();

        var input = new Vector3();
        input += transform.up * upInput;
        input += -transform.up * downInput;
        input = Vector3.ClampMagnitude(input, 1f);
        input *= movementSpeed;

        var factor = acceleration * Time.deltaTime;
        velocity.y = Mathf.Lerp(velocity.y, input.y, factor);
    }
    #endregion

    #region Selection

    public void CheckForMouseClick()
    {
        var selectInput = selectAction.ReadValue<float>();
        if(selectInput == 1)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                if(marker == null)
                marker = Instantiate(markerPrefab, hitInfo.point,Quaternion.identity);
                else
                {
                    marker.transform.position = hitInfo.point;
                }
            }
        }
    }


    #endregion
}
