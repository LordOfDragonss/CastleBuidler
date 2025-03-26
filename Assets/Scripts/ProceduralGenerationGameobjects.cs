using UnityEngine;

public class ProceduralGenerationGameobjects : MonoBehaviour
{
    [SerializeField] int width, maxheight;
    int height;
    [SerializeField] int minStoneHeight, maxStoneHeight;
    [SerializeField] GameObject dirt, grass,stone;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        height = maxheight;
        foreach(Transform child in transform)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        for (int x = 0; x < width; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight);

            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(maxStoneSpawnDistance, minStoneSpawnDistance);

            for (int y = 0; y < height; y++)
            {
                if (y < totalStoneSpawnDistance)
                {
                    spawnTile(stone, x, y);
                }
                else
                {
                    spawnTile(dirt, x, y);
                }
            }
            spawnTile(grass, x, height);
        }
    }

    public void spawnTile(GameObject tileObj, int width, int height)
    {
        tileObj = Instantiate(tileObj, new Vector2(width, height), Quaternion.identity, transform);
    }
}
