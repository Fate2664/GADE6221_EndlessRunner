using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.VFX;

public class FallingBuildingSpawner : MonoBehaviour
{
  
    float SpawnRate = 5f;
    float Counter = 0f;
   
    

    public List<GameObject> Obsctacles;
    public Transform Player;
    public GameObject AmbulanceIndicator;
    

    

    public List<float> DistanceAhead;

    private GameObject spawnedObstacle;

   
    



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
       

        if(Counter >= SpawnRate)
        {

            if (Obsctacles.Count > 0 && Player != null)
            {
                int randomIndex = Random.Range(0, Obsctacles.Count);
             
                Vector3 SpawnPosition = Vector3.zero;

                switch (randomIndex)
                {
                    //Building Spawn
                    case 0:
                        int BuildingSpawnPoint;
                        BuildingSpawnPoint = Random.Range(1, 3);
                       

                        if(BuildingSpawnPoint == 1)
                        {
                            SpawnPosition = new Vector3(-240, 0, Player.position.z - DistanceAhead[0]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.identity);
                        }

                        if(BuildingSpawnPoint == 2)
                        {
                            SpawnPosition = new Vector3(340, 0, Player.position.z - DistanceAhead[0]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.Euler(0,180,0));
                        }
                       
                        break;
                //Truck Spawn
                    case 1:
                        int TruckSpawnPoint;
                        TruckSpawnPoint = Random.Range(1, 3);

           

                        if (TruckSpawnPoint == 1)
                        {
                            SpawnPosition = new Vector3(22, 0, Player.position.z - DistanceAhead[1]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.identity);
                        }
                        
                        if (TruckSpawnPoint == 2)
                        {
                            SpawnPosition = new Vector3(-22, 0, Player.position.z - DistanceAhead[1]);
                            spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.identity);
                        }
                       

                        break;

                //Ambulance Spawn
                    case 2:
                        int AmbulanceSpawnPoint;
                        

                        AmbulanceSpawnPoint = Random.Range(1, 3);

                     
                        if (AmbulanceSpawnPoint == 1)
                        {
                            SpawnPosition = new Vector3(-22, 0, Player.position.z + DistanceAhead[2]);

                            Vector3 indicatorPosition = new Vector3(-22, 45, Player.position.z - DistanceAhead[3]);
                            AmbulanceIndicator = Instantiate(AmbulanceIndicator, indicatorPosition, Quaternion.identity);
                            

                        }

                        if (AmbulanceSpawnPoint == 2)
                        {
                            SpawnPosition = new Vector3(22, 0, Player.position.z + DistanceAhead[2]);

                            Vector3 indicatorPosition = new Vector3(22, 45, Player.position.z - DistanceAhead[3]);
                            AmbulanceIndicator = Instantiate(AmbulanceIndicator, indicatorPosition, Quaternion.identity);
                           
                        }
                        spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.Euler(0, 180, 0));
                      
                        break;


                }

                Destroy(spawnedObstacle, 5f);
                if (AmbulanceIndicator != null)
                {
                    Destroy(AmbulanceIndicator, 6f);



                }
                Counter = 0f;
             }

                


            }

                

        }

    }

    

   

