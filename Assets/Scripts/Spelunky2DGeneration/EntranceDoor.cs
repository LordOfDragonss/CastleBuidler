using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceDoor : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;
    public bool hasPlayerSpawned = false;
    public bool playerLeftEntrance = false;
    LayerManager layerManager = new LayerManager();

    private void Start()
    {
        layerManager = LayerManager.Instance;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerManager.CurrentLayer != 0 && playerLeftEntrance)
        {
            layerManager.PreviousLayer();
            SceneManager.LoadScene("Generated2D");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Player.tag)
        {
            playerLeftEntrance = true;
        }
    }

    void Update()
    {
        if (DungeonGeneration.READYFORPLAYER && !hasPlayerSpawned)
        {
            Instantiate(Player, spawnPoint);
            hasPlayerSpawned = true;
        }
    }
}
