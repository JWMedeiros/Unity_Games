using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float xAngle = 0f;
    float yAngle = 1f;
    float zAngle = 0f;
    void Update()
    {
        transform.Rotate(xAngle,yAngle,zAngle);
    }
}
