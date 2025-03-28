using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerController playerController;
    public DeathScreen deathScreen;
     



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

 

    private void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject.CompareTag("Obstacle"))
        {

           
            playerController.movementSpeed = 0;

            Destroy(gameObject);

             deathScreen.ShowDeathScreen();

        }
    }
}
