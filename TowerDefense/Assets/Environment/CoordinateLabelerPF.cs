using UnityEngine;
using TMPro;

//This script to be added to the Editor folder to be ignored when building the game.

//Executes in play mode and in edit mode
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabelerPF : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.yellow;
    //Orange color, RGB between 0-1
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //For Pathfinding Mobs
    GridManager gridManager;
    //For set path mobs
    //Waypoint waypoint;

    //Waypoint removed, gridMGR added
    void Awake()
    {
        gridManager= FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        //waypoint = GetComponentInParent<Waypoint>();
        label.enabled=false;
        DisplayCoordinates();   
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled=true;
        }
        SetLabelColor();
        ToggleLabels();
    }

    //Changed
    void SetLabelColor ()
    {
        if (gridManager==null){return;}

        Node node = gridManager.GetNode(coordinates);

        if (node==null) {return;}

        if (!node.isWalkable)
        {
            label.color=blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color= exploredColor;
        }
        else
        {
            label.color=defaultColor;
        }
    }

    void DisplayCoordinates()
    {
        if (gridManager==null) {return;}
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/gridManager.UnityGridSize);
        label.text = coordinates.x+","+coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name= coordinates.ToString();
    }

    void ToggleLabels ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
