using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    InputAction pauseAction;
    PlayerInput input;

    [SerializeField] private TMP_Dropdown movementSwapper;



    static bool isPaused;

    [SerializeField] GameObject pauseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        pauseAction = input.actions["pause"];
        pauseAction.performed += OnPausePressed;
        pauseScreen.SetActive(false);
    }

    private void OnPausePressed(InputAction.CallbackContext ctx)
    {
        TogglePause();
        CameraController.ToggleCameraControl();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            CollectSettings();
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            UpdateSettings();
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void CollectSettings()
    {
        movementSwapper.value = (int)PlayerController.instance.movementControl;
    }

    public void UpdateSettings()
    {
        PlayerController.instance.movementControl = (PlayerController.MovementControl)movementSwapper.value;
    }





}
