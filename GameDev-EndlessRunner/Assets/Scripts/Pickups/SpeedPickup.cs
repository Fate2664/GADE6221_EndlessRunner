using UnityEngine;

public class SpeedPickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        GameObject speedobj = this.gameObject;
        if (collision.gameObject.CompareTag("Player"))
        {
            PickupManager.pickup = "SpeedPickup";
            PickupManager.PowerUpCheck = true;
            Destroy(speedobj);
        }
    }
}
