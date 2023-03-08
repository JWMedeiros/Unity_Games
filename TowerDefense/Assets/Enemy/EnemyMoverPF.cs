using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Enemy))]

public class EnemyMoverPF : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    void Awake()
    {
        enemy=GetComponent<Enemy>();
        gridManager=FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates=pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine (FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    //Coroutine (Similar to Async in JS, after yield will go through the rest of start.)
    IEnumerator FollowPath()
    {
        for (int i=1; i<path.Count; i++)
        {
            Vector3 startPosn = transform.position;
            Vector3 endPosn = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endPosn);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosn, endPosn, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}