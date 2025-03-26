using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    [SerializeField] string SceneName;
    private void OnMouseUp()
    {
        SwapSceneOnClick();
    }

    private void SwapSceneOnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}
