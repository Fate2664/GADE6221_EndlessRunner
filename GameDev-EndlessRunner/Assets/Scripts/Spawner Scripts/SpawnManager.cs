using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner RoadSpawner;
    LandSpawner LandSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RoadSpawner = GetComponent<RoadSpawner>();
        LandSpawner = GetComponent<LandSpawner>();
    }

   

    public void SpawnTriggerEntered()
    {
        if (PickupManager.PowerUpCheck && PickupManager.pickup == "SpeedPickup")
        {
            Invoke(nameof(SpawnRoad), 1f);
        }
        else
        {
            Invoke(nameof(SpawnRoad), 0.4f);
        }
        LandSpawner.SpawnLand();
        LandSpawner.DestroyLand();

    }



    private void SpawnRoad()
    {
        RoadSpawner.MoveRoad();
    }
}


