using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{

    float upperBound = 30.0f;
    float lowerBound = -10.0f;

    // Update is called once per frame
    void Update()
    {
        CheckAndDestroyOutOfBounds();
    }

    // Checks if a unit is out of bounds in destory it if that's the case
    void CheckAndDestroyOutOfBounds()
    {
        if (transform.position.z > upperBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
