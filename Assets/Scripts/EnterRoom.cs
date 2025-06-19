using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterRoomWithClick : MonoBehaviour
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
    private void OnMouseUp()
    {
        ConfirmationScreen.enabled = true;
    }

    private void SwapSceneOnYes()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void CloseConfirmationScreen()
    {
        ConfirmationScreen.enabled = false;
    }
        
}
