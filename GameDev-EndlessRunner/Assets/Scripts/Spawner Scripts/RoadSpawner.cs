using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float Zoffset = 160f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderByDescending(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {

        GameObject movedRoad = roads[0];
        float newZoffest = roads[roads.Count - 1].transform.position.z - Zoffset;
        float newYoffset = 8 + 3.256991f;
        float newXoffset = -3.64609f;

        roads.RemoveAt(0);
        //idk why I need to add an x and y offset but if I don't, the roads spawn somewhere else??????????
        movedRoad.transform.position = new Vector3(newXoffset, newYoffset, newZoffest);
        roads.Add(movedRoad);
    }

   

}
