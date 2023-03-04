using UnityEngine;
using TMPro;

//This script to be added to the Editor folder to be ignored when building the game.

//Executes in play mode and in edit mode
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled=false;
        waypoint = GetComponentInParent<Waypoint>();
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

    void SetLabelColor ()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
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
