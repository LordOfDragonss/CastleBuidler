using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterRoom : MonoBehaviour
{
    [SerializeField] string SceneName;
    public Canvas ConfirmationScreen;

    public Button ConfirmButton;
    public Button ExitButton;

    private void Start()
    {
        ConfirmationScreen.enabled = false;
        ConfirmButton.onClick.AddListener(SwapSceneOnYes);
        ExitButton.onClick.AddListener(CloseConfirmationScreen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ConfirmationScreen.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            CameraController.ToggleCameraControl();
        }
    }

    private void SwapSceneOnYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void CloseConfirmationScreen()
    {
        Time.timeScale = 1;
        ConfirmationScreen.enabled = false;
        CameraController.ToggleCameraControl();
    }
        
}
