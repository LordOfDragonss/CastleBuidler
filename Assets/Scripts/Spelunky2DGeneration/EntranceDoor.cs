using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;
    public bool hasPlayerSpawned = false;

    void Update()
    {
        if (DungeonGeneration.READYFORPLAYER && !hasPlayerSpawned)
        {
            Instantiate(Player,spawnPoint);
            hasPlayerSpawned = true;
        }
    }
}
