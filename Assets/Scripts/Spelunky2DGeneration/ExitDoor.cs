using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private LayerManager layerManager;

    private void Start()
    {
        layerManager = LayerManager.Instance;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        NextLevel();
    }

    public void NextLevel()
    {
        layerManager.NextLayer();
        SceneManager.LoadScene("Generated2D");
    }
}
