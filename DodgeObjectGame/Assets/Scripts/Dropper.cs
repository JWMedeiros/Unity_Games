using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    int timeToWait;
    MeshRenderer renderer;
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        timeToWait= Random.Range(5,10);
        renderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        renderer.enabled = false;
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>timeToWait)
        {
            renderer.enabled = true;
            body.useGravity = true;
        }
    }
}
