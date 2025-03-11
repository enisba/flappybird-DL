using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AgentsManager : MonoBehaviour
{
    public GameObject birdPrefab;
    public int initialBirdCount = 10;
    private List<GameObject> birds = new List<GameObject>();
    private Dictionary<GameObject, int> birdScores = new Dictionary<GameObject, int>();

    void Start()
    {
        SpawnBirds();
    }

    void SpawnBirds()
    {
        for (int i = 0; i < initialBirdCount; i++)
        {
            GameObject newBird = Instantiate(birdPrefab, new Vector3(-2, 0, 0), Quaternion.identity);
            birds.Add(newBird);
            birdScores[newBird] = 0;
        }
    }

    public void ReportScore(GameObject bird, int score)
    {
        if (birdScores.ContainsKey(bird))
        {
            birdScores[bird] = score;
        }
    }

    public void BirdDied(GameObject bird)
    {
        if (birds.Contains(bird))
        {
            birds.Remove(bird);
            Destroy(bird);
        }

        if (birds.Count == 0)
        {
            Debug.Log("🛑 Tüm ajanlar öldü, en iyi ajan belirlenecek...");
            RestartGeneration();
        }
    }

    void RestartGeneration()
    {
        if (birdScores.Count > 0)
        {
            GameObject bestBird = birdScores.OrderByDescending(b => b.Value).First().Key;
            int bestScore = birdScores[bestBird];

            Debug.Log("🏆 En iyi ajan seçildi! Skor: " + bestScore);
        }
        else
        {
            Debug.Log("⚠️ Hiçbir ajan skor yapamadı!");
        }

        birds.Clear();
        birdScores.Clear();

        for (int i = 0; i < initialBirdCount; i++)
        {
            GameObject newBird = Instantiate(birdPrefab, new Vector3(-2, 0, 0), Quaternion.identity);
            birds.Add(newBird);
            birdScores[newBird] = 0;
        }
    }
}
