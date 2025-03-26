using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour
{

    private int intialAmount = 10;
    private float landSize = 160f;
    private float xPosLeft = 139f;
    private float xPosRight = -139f;
    private float lastZ = 190f;

    public List<GameObject> plotsofLand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < intialAmount; i++)
        {
            SpawnLand();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLand()
    {
        GameObject landLeft = plotsofLand[Random.Range(0, plotsofLand.Count)];
        GameObject landRight = plotsofLand[Random.Range(0, plotsofLand.Count)];

        float zPos = lastZ - landSize;

        Instantiate(landLeft, new Vector3(xPosLeft, 0, zPos), landLeft.transform.rotation);
        Instantiate(landRight, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));

        lastZ -= landSize;
    }
}
