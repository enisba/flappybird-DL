using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Boruların hızı

    void Update()
    {
        if (transform != null) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x < -10f) 
        {
            Destroy(gameObject);
        }
    }
}
