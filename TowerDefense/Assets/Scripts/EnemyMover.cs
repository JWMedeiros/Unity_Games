using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    void Start()
    {
        StartCoroutine (FollowPath());
    }

    //Coroutine (Similar to Async in JS, after yield will go through the rest of start.)
    IEnumerator FollowPath()
    {
        foreach (Waypoint point in path)
        {
            transform.position = point.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
