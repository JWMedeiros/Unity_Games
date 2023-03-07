using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tells unity to serialize this field
[System.Serializable]

//Can't attach pure C# classes to a game object
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    //Constructor
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable= isWalkable;
    }
}
