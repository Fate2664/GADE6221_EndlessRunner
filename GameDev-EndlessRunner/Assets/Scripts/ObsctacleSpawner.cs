using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FallingBuildingSpawner : MonoBehaviour
{
  
    float SpawnRate = 5f;
    float Counter = 0f;
   
    

    public List<GameObject> Buildings;
    public Transform Player;

    public float DistanceAhead = 30f;
   

    // Update is called once per frame
    void Update()
    {
        SpawnFallingBuilding();
    }

    private void SpawnFallingBuilding()
    {
        Counter += Time.deltaTime;
       

        if(Counter >= SpawnRate)
        {

            GameObject SpawnBuilding = Buildings[0];

            if (Buildings.Count > 0 && Player != null)
            {
                int randomIndex = Random.Range(0, Buildings.Count);
                SpawnBuilding = Buildings[randomIndex];
                Vector3 SpawnPosition;

                switch (randomIndex)
                {
                    case 0:
                    SpawnPosition = new Vector3(-78, 0, Player.position.z - DistanceAhead);

                    Instantiate(SpawnBuilding, SpawnPosition, Quaternion.identity);
                        break;

                    case 1:
                        SpawnPosition = new Vector3(22, 0, Player.position.z - DistanceAhead);

                        Instantiate(SpawnBuilding, SpawnPosition, Quaternion.identity);
                        break;


                }

                   
                






            }

            
         
                Counter = 0f;

        }

       

    }
}
