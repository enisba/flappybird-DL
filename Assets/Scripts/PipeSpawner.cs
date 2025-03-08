using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f; // Boruların çıkış süresi (Daha sık boru oluşturmak için azaltıldı)
    public float minHeight = -3f;
    public float maxHeight = 3f;
    public int initialPipes = 2; // Oyunun başında kaç boru spawn edilecek
    public float offScreenX = 12f; // Boruların ekranın sağında spawn olacağı X konumu
    public float spawnSpacing = 12f; // Boruların arasındaki mesafe azaltıldı

    private float nextSpawnX; // Bir sonraki borunun X konumunu takip eder

    void Start()
    {
        nextSpawnX = offScreenX;

        // Oyunun başında ekranda hiç boru yok, ama ekranın sağında düzenli borular oluştur
        for (int i = 0; i < initialPipes; i++)
        {
            SpawnPipe(nextSpawnX);
        }

        // Sonrasında belirli aralıklarla boru oluşturmaya devam et
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
