using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 155f;
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
        roads.RemoveAt(0);
        float newZoffest = roads[roads.Count - 1].transform.position.z - offset;
        movedRoad.transform.position = new Vector3(0, 0 , newZoffest);
        roads.Add(movedRoad);
    }

}
