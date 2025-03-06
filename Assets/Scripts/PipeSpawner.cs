using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; 
    public float spawnRate = 4f; 
    public float minHeight = -3f;
    public float maxHeight = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnRate);
    }

    void SpawnPipe()
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(5f, randomHeight, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
