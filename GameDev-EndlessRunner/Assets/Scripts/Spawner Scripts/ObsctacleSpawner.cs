using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.VFX;

public class FallingBuildingSpawner : MonoBehaviour
{
  
    float SpawnRate = 5f;
    float Counter = 0f;
   
    

    public List<GameObject> Buildings;
    public Transform Player;

    public float DistanceAhead = 30f;

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

            if (Buildings.Count > 0 && Player != null)
            {
                int randomIndex = Random.Range(0, Buildings.Count);
               
                Vector3 SpawnPosition = Vector3.zero;

                switch (randomIndex)
                {
                    case 0:
                    SpawnPosition = new Vector3(-78, 0, Player.position.z - DistanceAhead);

                    
                        break;

                    case 1:
                        SpawnPosition = new Vector3(22, 0, Player.position.z - DistanceAhead);

                       
                        break;


                }

                spawnedObstacle = Instantiate(Buildings[randomIndex], SpawnPosition, Quaternion.identity);

                Destroy(spawnedObstacle, 5f);

            }

                Counter = 0f;

        }

    }

    

   
}
