using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game.");
        Debug.Log("Use WASD to move your player square around the field.");
        Debug.Log("Please avoid hitting the objects and walls in the arena.");
    }

    void MovePlayer()
    {
        //Add to, the axis, every frame, independant of Framerate.
        float zValue = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        transform.Translate(xValue,0,zValue);
    }
}
