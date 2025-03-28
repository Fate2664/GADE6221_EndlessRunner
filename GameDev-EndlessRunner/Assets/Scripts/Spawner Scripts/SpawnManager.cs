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

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTriggerEntered()
    {
        Invoke(nameof(SpawnRoad), 0.2f);
        LandSpawner.SpawnLand();
        LandSpawner.DestroyLand();

    }



    private void SpawnRoad()
    {
        RoadSpawner.MoveRoad();
    }
}

   
