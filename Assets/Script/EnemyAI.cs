using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;   
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    
    NavMeshAgent navMeshAgent;
    float distanceTarget = Mathf.Infinity;
    bool isProvoked = false;

    // 1. Checking is the enemy provoked - is the player in enemy chaseRange
    // 2. 
    
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
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
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
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log(name + "has Attacked " + target.name);
    }

    private void ChaseTarget()   // method that set destination of navmesh agent to chase the player 
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() // method to show the enemy reaction range
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;       
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
   
}
