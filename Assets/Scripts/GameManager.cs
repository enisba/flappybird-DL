using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int highScore = 0; // En yüksek skor
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // High score'u göstermek için Text
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // High Score’u PlayerPrefs'ten yükle
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // UI’ı güncelle
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }

        gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Yeni Skor: " + score);

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log("ScoreText Güncellendi: " + scoreText.text);
        }
        else
        {
            Debug.LogError("scoreText referansı NULL! UI Text bağlı mı?");
        }
    }

    public void GameOver()
    {
        // Skor, high score’dan büyük mü kontrol et
        if (score > highScore)
        {
            highScore = score;
            Debug.Log("Yeni High Score: " + highScore);

            // PlayerPrefs’e kaydet
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Değişiklikleri diske yazar

            // High score metnini güncelle
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + highScore;
            }
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
