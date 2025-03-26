using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    LandSpawner LandSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        LandSpawner = GetComponent<LandSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        LandSpawner.SpawnLand();
    }
}
