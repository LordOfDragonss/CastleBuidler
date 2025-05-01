using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tiles;
    void Start()
    {
        int r = Random.Range(0,tiles.Length);
        if (tiles[r]!= null)
        {
            Instantiate(tiles[r],transform);
        }
    }
}
