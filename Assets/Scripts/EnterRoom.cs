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
            CameraController.instance.isInControlOfCamera = false;
        }
    }

    private void SwapSceneOnYes()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void CloseConfirmationScreen()
    {
        ConfirmationScreen.enabled = false;
        CameraController.instance.isInControlOfCamera = true;
    }
        
}
