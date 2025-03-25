using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    private float yOffset = 5f;
    private float zOffset = -25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
    }
}
