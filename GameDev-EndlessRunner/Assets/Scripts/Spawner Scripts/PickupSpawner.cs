using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    private float xPosLeft = 20f;
    private float xPosRight = -20f;
    private float distanceAhead = 700f;
    private float yHeight = 10f;
    private float counter = 0f;
    private float spawnRate = 5f;
    public List<GameObject> pickups;
    private Transform player;
    private Vector3 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPickup();
    }

    public void SpawnPickup()
    {
        counter += Time.deltaTime;
        int randomIndex = Random.Range(0, pickups.Count);
        if (counter >= spawnRate)
        {
            if (pickups.Count > 0)
            {
                int pickupSpawnPoint = Random.Range(0, 3);
                if (pickupSpawnPoint == 0)
                {
                    spawnPosition = new Vector3(xPosLeft, yHeight, player.position.z - distanceAhead);
                }
                else if (pickupSpawnPoint == 1) 
                {
                   spawnPosition = new Vector3(xPosRight,yHeight , player.position.z - distanceAhead);
                }

                GameObject pickupSpawned = Instantiate(pickups[randomIndex], spawnPosition, Quaternion.identity);
               
                Destroy(pickupSpawned,5f);

                counter = 0f;
            }
        }
    }
}
