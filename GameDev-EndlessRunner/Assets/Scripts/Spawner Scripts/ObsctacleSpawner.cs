using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.VFX;

public class ObstacleSpawner : MonoBehaviour
{

    float SpawnRate = 5f;
    float Counter = 0f;



    public List<GameObject> Obsctacles;
    public Transform Player;
    public GameObject AmbulanceIndicator;




    public List<float> DistanceAhead;
    public int obstacleIndex = 0;
    private GameObject spawnedObstacle;
    private Vector3 indicatorPosition;
    private Vector3 spawnObstaclePosition;
    private GameObject passTrigger;
    private GameObject spawnedTrigger;
    private float yHeightPassTrigger = 8f;
    private Vector3 spawnTriggerPosition;


    private void Start()
    {
        passTrigger = GameObject.Find("ObstaclePassTrigger");
    }



    // Update is called once per frame
    void Update()
    {
        SpawnObstacle();
        DifficultyScaling();


    }

    private void DifficultyScaling()
    {
        float GameCounter = Time.deltaTime;
        float DiffIncInterval = 5.0f;

        if (GameCounter > DiffIncInterval && SpawnRate > 2)
        {
            SpawnRate += -0.5f;
            Debug.Log("It is now harder");

        }


    }

    private void SpawnObstacle()
    {
        Counter += Time.deltaTime;


        if (Counter >= SpawnRate)
        {

            if (Obsctacles.Count > 0 && Player != null)
            {
                int randomIndex = Random.Range(0, Obsctacles.Count);


                switch (randomIndex)
                {
                    //Building Spawn
                    case 0:
                        int BuildingSpawnPoint;
                        BuildingSpawnPoint = Random.Range(1, 3);


                        if (BuildingSpawnPoint == 1)
                        {
                            spawnObstaclePosition = new Vector3(-240, 0, Player.position.z - DistanceAhead[0]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], spawnObstaclePosition, Quaternion.identity);
                        }

                        if (BuildingSpawnPoint == 2)
                        {
                            spawnObstaclePosition = new Vector3(340, 0, Player.position.z - DistanceAhead[0]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], spawnObstaclePosition, Quaternion.Euler(0, 180, 0));
                        }
                        break;
                    //Truck Spawn
                    case 1:
                        int TruckSpawnPoint;
                        TruckSpawnPoint = Random.Range(1, 3);
                        obstacleIndex = 1;

                        if (TruckSpawnPoint == 1)
                        {
                            spawnObstaclePosition = new Vector3(22, 0, Player.position.z - DistanceAhead[1]);
                            spawnTriggerPosition = new Vector3(-22, yHeightPassTrigger, Player.position.z - DistanceAhead[1]);
                        }

                        if (TruckSpawnPoint == 2)
                        {
                            spawnObstaclePosition = new Vector3(-22, 0, Player.position.z - DistanceAhead[1]);
                            spawnTriggerPosition = new Vector3(22, yHeightPassTrigger, Player.position.z - DistanceAhead[1]);
                        }

                        spawnedObstacle = Instantiate(Obsctacles[randomIndex], spawnObstaclePosition, Quaternion.identity);
                        spawnedTrigger = Instantiate(passTrigger, spawnTriggerPosition, Quaternion.identity);


                        break;

                    //Ambulance Spawn
                    case 2:
                        int AmbulanceSpawnPoint;
                        AmbulanceSpawnPoint = Random.Range(1, 3);
                        obstacleIndex = 0;


                        if (AmbulanceSpawnPoint == 1)
                        {
                            spawnObstaclePosition = new Vector3(-22, 0, Player.position.z + DistanceAhead[2]);
                            spawnTriggerPosition = new Vector3(22, yHeightPassTrigger, Player.position.z - DistanceAhead[2]);
                            indicatorPosition = new Vector3(-22, 45, Player.position.z - DistanceAhead[3]);

                        }

                        if (AmbulanceSpawnPoint == 2)
                        {
                            spawnObstaclePosition = new Vector3(22, 0, Player.position.z + DistanceAhead[2]);
                            spawnTriggerPosition = new Vector3(-22, yHeightPassTrigger, Player.position.z - DistanceAhead[2]);
                            indicatorPosition = new Vector3(22, 45, Player.position.z - DistanceAhead[3]);
                        }
                        spawnedTrigger = Instantiate(passTrigger, spawnTriggerPosition, Quaternion.identity);
                        AmbulanceIndicator = Instantiate(AmbulanceIndicator, indicatorPosition, Quaternion.identity);
                        spawnedObstacle = Instantiate(Obsctacles[randomIndex], spawnObstaclePosition, Quaternion.Euler(0, 180, 0));
                        break;


                }

                Destroy(spawnedObstacle, 5f);
                Destroy(spawnedTrigger, 5f);
                Destroy(AmbulanceIndicator, 6f);

                Counter = 0f;
            }




        }



    }

}





