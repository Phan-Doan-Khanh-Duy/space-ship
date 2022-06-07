using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        //ScreenToWorldPoint is 4 point of camera
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        minX = -bounds.x + 0.09f;
        maxX = bounds.x - 0.09f;

        minY = -bounds.y + 1f;
        maxY = bounds.y - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;//posision of plane

        // set x
        if (temp.x < minX) // smaller will go through
        {
            temp.x = minX; // go inside
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        // set y
        if (temp.y < minY) // smaller will go through
        {
            temp.y = minY; // go inside
        }
        else if (temp.y > maxY)
        {
            temp.y = maxY;
        }

        transform.position = temp;
    }
}
