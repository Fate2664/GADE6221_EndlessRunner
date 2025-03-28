using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    public float yOffset = 5f;
    public float zOffset = -25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {


            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
        }
    }
}
