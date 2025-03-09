using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isDead = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
void OnCollisionEnter2D(Collision2D collision)
{
    GameManager gm = FindFirstObjectByType<GameManager>();
    if (gm != null)
    {
        gm.GameOver();
    }
    else
    {
        Debug.LogError("GameManager not found!");
    }

    isDead = true;
    Time.timeScale = 0;
}



    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        Time.timeScale = 1; 
    }

    
}
