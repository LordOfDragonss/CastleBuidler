using UnityEngine;

public class RandomNpcSpawner : MonoBehaviour
{

    public GameObject NPCPrefab;
    public int amount;

    public void OnTriggerEnter(Collider other)
    {
        SpawnNpcs();
    }

    [SerializeField] private float spawnRangeX = 10f;
    [SerializeField] private float spawnRangeZ = 5f;

    public void SpawnNpcs()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                0f,
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            Vector3 spawnPosition = transform.position + randomOffset;

            Instantiate(NPCPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
