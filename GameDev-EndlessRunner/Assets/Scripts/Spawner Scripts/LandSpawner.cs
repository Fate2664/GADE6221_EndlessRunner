using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LandSpawner : MonoBehaviour
{

    private int intialAmount = 10;
    private float landSize = 160f;
    private float xPosLeft = 139f;
    private float xPosRight = -139f;
    private float previousZ = 190f;

    public List<GameObject> plotsofLand;
    private List<GameObject> activePlots = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject FirstLandLeft = GameObject.Find("Land_Empty");
        GameObject FirstLandRight = GameObject.Find("Land_Empty (1)");
        activePlots.Add(FirstLandLeft);
        activePlots.Add(FirstLandRight);

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

        GameObject landLeft = Instantiate(plotsofLand[Random.Range(0, plotsofLand.Count)], new Vector3(xPosLeft, 0, previousZ - landSize), Quaternion.identity);
        GameObject landRight = Instantiate(plotsofLand[Random.Range(0, plotsofLand.Count)], new Vector3(xPosRight, 0, previousZ - landSize), new Quaternion(0, 180, 0,0));

        activePlots.Add(landLeft);
        activePlots.Add(landRight);
        

        previousZ -= landSize;
    }

    public void DestroyLand()
    {
        if (activePlots.Count > 0)
        {
            GameObject firstPlot = activePlots[0];
            Destroy(firstPlot);
            activePlots.RemoveAt(0);
            Destroy(activePlots[0]); //destroy the right side aswell
            activePlots.RemoveAt(0);
        }
        
    }

    
}
