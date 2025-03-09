using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class FlappyAgent : Agent
{
    Rigidbody2D rb;
    public float jumpForce = 5f;
    Vector3 startingPosition;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position; 
    }

    public override void OnEpisodeBegin()
    {
        rb.linearVelocity = Vector2.zero;

        transform.position = startingPosition;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);
        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 1)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        AddReward(0.01f);

        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            AddReward(-1f);
            EndEpisode();
        }
        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions.Array[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreTrigger"))
        {
            AddReward(1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    
}
