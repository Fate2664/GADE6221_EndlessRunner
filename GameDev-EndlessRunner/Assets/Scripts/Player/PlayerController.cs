using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float StrafeSpeed = 10.0f;
    public static float moveH;
    public float MoveForwardSpeed = 300.0f;
    public SpawnManager spawnManager;
    public Score scoreManager;
    private int desiredLane = 1; //0 = left lane; 1 = right lane
    public float laneDistance = 20.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane > 1)
            {
                desiredLane = 1;
            }
        }

    }

    void FixedUpdate()
    {
        MoveCharacter();

    }

    private void MoveCharacter()
    {
        Vector3 targetPos = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPos -= Vector3.left * laneDistance;
        }
        else if (desiredLane == 1)
        {
            targetPos -= Vector3.right * laneDistance;
        }

        Vector3 moveDirection = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * StrafeSpeed);
        transform.position = new Vector3(moveDirection.x, transform.position.y, transform.position.z - (MoveForwardSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("RoadSpawn"))
        {
            spawnManager.SpawnTriggerEntered();

        }
        if (collision.CompareTag("StaticObstacleTrigger"))
        {
            scoreManager.IncrementScore();
        }
        if (collision.CompareTag("MovingObstacleTrigger"))
        {
            scoreManager.IncrementScore();
        }
    }
}