using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    /// bowman stuff
    
    public float projectileLifetime;
    /// 




    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float fireSpeed;
    public bool alreadyAttacked;

    //states
    public float spotRange, attackRange;
    bool playerInSight, playerInRange;

    public bool isBowman;


    private void Awake()
    {

      int bowmanChance = Random.Range(1, 5);
        if(bowmanChance == 4)
        {
            isBowman = true;
        }


        if(isBowman == true)
        {

        }
        //find playertag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        //chech for player in range
        playerInSight = Physics.CheckSphere(transform.position, spotRange, whatIsPlayer);
        playerInRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInRange && !playerInSight) Patrolling();
        if (!playerInRange && playerInSight) ChasePlayer();
        if (playerInRange && playerInSight) AttackPlayer();

    }
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToPoint = transform.position - walkPoint;

        if(distanceToPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

      
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        gameObject.GetComponent<EnemyAttack>().Attack();
    }
    
        
}
