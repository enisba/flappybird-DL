using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int highScore = 0; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
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
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(highScoreText != null)
            highScoreText.text = "High Score: " + highScore;

        if(scoreText != null)
            scoreText.text = "0";

        gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;

        if(scoreText != null)
            scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;

        if(scoreText != null)
            scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if(highScoreText != null)
                highScoreText.text = "High Score: " + highScore;
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
