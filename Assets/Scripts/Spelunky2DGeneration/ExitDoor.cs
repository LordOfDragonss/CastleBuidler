using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        NextLevel();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Generated2D");
    }
}
