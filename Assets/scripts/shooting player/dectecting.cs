using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
using UnityEngine.UI;

public class dectecting : enmycontrol
{
    public float bulletSpeed = 50f;
    public GameObject bulletPrefab;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, WhatisPlayer;

    //patrolling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //states
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange , WhatisPlayer); 

        if(!playerInSightRange)
        {
            Patrolling();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void Patrolling()
    {
        if(!walkPointSet)
        {
            SearchWalkPoint();
        }
        
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);
        float RandomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround))
        {
           walkPointSet = true; 
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {

    }

    internal override void OnTriggerEnter(Collider collision)
    {

        //base.OnTriggerEnter( collision);

        if (!bulletPrefab) return;
      

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
           


            GameObject bullet = Instantiate(bulletPrefab, transform);
          bullet.GetComponent<Rigidbody>().AddForce(transform.forward* bulletSpeed, ForceMode.Impulse);
            bullet.transform.parent = null;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
       // Gizmos.color= Color.red;
       //    Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }



}
