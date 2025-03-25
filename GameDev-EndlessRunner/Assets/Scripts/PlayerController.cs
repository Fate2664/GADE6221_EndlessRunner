using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public static float moveH;
    public static float moveV;
    public SpawnManager spawnManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        MoveCharacter(moveH, moveV);
    }

    private void MoveCharacter(float directionH, float directionV)
    {
        transform.Translate(new Vector3 (directionH * movementSpeed, 0, directionV * movementSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
