using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("World Grid Size - Should match UnityEditor Snap Settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize{get{return unityGridSize;}}
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int,Node>();
    public Dictionary<Vector2Int, Node> Grid {get{return grid;}}
    
    void Awake() 
    {
        CreateGrid();    
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable=false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int,Node> entry in grid)
        {
            entry.Value.connectedTo=null;
            entry.Value.isExplored=false;
            entry.Value.isPath=false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 posn)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(posn.x/unityGridSize);
        coordinates.y = Mathf.RoundToInt(posn.z/unityGridSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 posn = new Vector3();
        posn.x = coordinates.x*unityGridSize;
        posn.z = coordinates.y*unityGridSize;
        return posn;
    }

    void CreateGrid()
    {
        for(int x=0;x<gridSize.x; x++)
        {
            for(int y=0; y<gridSize.y;y++)
            {
                Vector2Int coordinates = new Vector2Int(x,y);
                grid.Add(coordinates, new Node(coordinates,true));
                Debug.Log(grid[coordinates].coordinates + " = "+grid[coordinates].isWalkable);
            }
        }
    }
}
