using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;   
    [SerializeField] float chaseRange = 5f;
    
    
    NavMeshAgent navMeshAgent;
    float distanceTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
   
    void Update()
    {
        distanceTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (distanceTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distanceTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();           
        }
    }

    private void AttackTarget()
    {
        Debug.Log(name + "has Attacked " + target.name);
    }

    private void ChaseTarget()   // method that set destination of navmesh agent to chase the player 
    {
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected() // method to show the enemy reaction range
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;       
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
   
}
