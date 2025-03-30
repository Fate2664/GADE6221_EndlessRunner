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
                    case 0:
                    SpawnPosition = new Vector3(-78, 0, Player.position.z - DistanceAhead[0]);
                        Debug.Log("Building");

                    
                        break;

                    case 1:
                        SpawnPosition = new Vector3(22, 0, Player.position.z - DistanceAhead[1] );
                        Debug.Log("Truck");

                        break;

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
                        
                        Debug.Log("Ambulance");
                        break;


                }

                if (randomIndex == 0 || randomIndex == 1)
                {
                    spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.identity);
                }

                if (randomIndex == 2)
                {
                    spawnedObstacle = Instantiate(Obsctacles[randomIndex], SpawnPosition, Quaternion.Euler(0,180,0));
                }

                
                   
                    
                

                Destroy(spawnedObstacle, 5f);
                if (AmbulanceIndicator != null)
                {
                    Destroy(AmbulanceIndicator, 6f);



                }


            }

                Counter = 0f;

        }

    }

    

   
}
