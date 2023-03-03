using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;
    void Start()
    {
        enemy=GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine (FollowPath());
    }

    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    //Coroutine (Similar to Async in JS, after yield will go through the rest of start.)
    IEnumerator FollowPath()
    {
        foreach (Waypoint point in path)
        {
            Vector3 startPosn = transform.position;
            Vector3 endPosn = point.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosn);

            while(travelPercent<1f)
            {
                travelPercent+= Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosn, endPosn, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
