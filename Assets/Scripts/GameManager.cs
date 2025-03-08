using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

public void AddScore(int amount)
{
    score += amount;
    Debug.Log("Yeni Skor: " + score); // Console'da skoru göster

    if (scoreText != null)
    {
        scoreText.text = score.ToString();
        Debug.Log("ScoreText Güncellendi: " + scoreText.text); // Console'da güncellenen metni göster
    }
    else
    {
        Debug.LogError("scoreText referansı NULL! UI Text bağlı mı?");
    }
}

}
