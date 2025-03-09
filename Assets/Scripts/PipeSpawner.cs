using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f; 
    public float minHeight = -3f;
    public float maxHeight = 3f;
    public int initialPipes = 2; 
    public float offScreenX = 12f; 
    public float spawnSpacing = 12f; 

    private float nextSpawnX; 

    void Start()
    {
        nextSpawnX = offScreenX;

        for (int i = 0; i < initialPipes; i++)
        {
            SpawnPipe(nextSpawnX);
        }

        InvokeRepeating(nameof(SpawnNextPipe), spawnRate, spawnRate);
    }

    void SpawnNextPipe()
    {
        SpawnPipe(nextSpawnX);
    }

    void SpawnPipe(float xPosition)
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(xPosition, randomHeight, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
