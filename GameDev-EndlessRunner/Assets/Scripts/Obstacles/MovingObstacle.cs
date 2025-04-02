using UnityEngine;
using System.Collections.Generic;
public class MovingObstacle : MonoBehaviour
{

    private float[] MovementSpeed = { 500, 300 };
    private int obstacleIndex;
 
 

    // Update is called once per frame
    void Update()
    {
        switch (obstacleIndex)
        {
            case 0:
                transform.Translate(Vector3.forward * MovementSpeed[0] * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector3.forward * MovementSpeed[1] * Time.deltaTime);
                break;
        }

    }
}
