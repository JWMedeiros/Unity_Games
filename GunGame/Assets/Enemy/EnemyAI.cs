using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange=5f;
    [SerializeField] float turnSpeed =5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget= Mathf.Infinity;
    Transform target;
    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target=FindObjectOfType<PlayerHealth>().transform;
    }

    void OnDrawGizmos() {
        Gizmos.color=new Color(1,0,1,0.75f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        //Provoke the enemy when it is attacked
        isProvoked=true;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget<=chaseRange)
        {
            isProvoked=true;
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack",false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation= Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*turnSpeed);
    }
}
