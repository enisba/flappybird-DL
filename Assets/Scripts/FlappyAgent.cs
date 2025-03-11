using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class FlappyAgent : Agent
{
    Rigidbody2D rb;
    private AgentsManager agentsManager;
    private bool isDead = false;
    private int score = 0;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        agentsManager = FindFirstObjectByType<AgentsManager>();

        if (agentsManager == null)
        {
            Debug.LogError("❌ AgentsManager bulunamadı! Sahneye 'AgentsManager' eklediğinden emin ol.");
        }
    }

    public override void OnEpisodeBegin()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector3(-2, Random.Range(-2f, 2f), 0);
        isDead = false;
        score = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 1 && !isDead)
        {
            rb.linearVelocity = Vector2.up * 5f;
        }

        AddReward(-0.001f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        actionsOut.DiscreteActions.Array[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("ScoreTrigger"))
    {
        score++; // **Ajanın skorunu artır**
        AddReward(1f); // **AI için ödül**
        Debug.Log("✅ Skor Arttı! Yeni skor: " + score);
    }
}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground")))
        {
            isDead = true;
            AddReward(-1f);

            if (agentsManager != null)
            {
                agentsManager.ReportScore(gameObject, score);
                agentsManager.BirdDied(gameObject);
            }
        }
    }
}
