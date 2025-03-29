using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float StrafeSpeed = 300.0f;
    public static float moveH;
    public float MoveForwardSpeed = 300.0f;
    public SpawnManager spawnManager;
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal");
      
    }

    void FixedUpdate()
    {
        MoveCharacter(moveH);

    }

    private void MoveCharacter(float directionH)
    {
     
        transform.Translate(new Vector3 (directionH * StrafeSpeed, 0, MoveForwardSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
