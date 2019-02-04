//using UnityEngine;
// using UnityEngine.AI;
//using System.Collections;

//public class EnemyMovement : MonoBehaviour
//{
//    Transform player;               // Reference to the player's position.
//    PlayerHealth playerHealth;      // Reference to the player's health.
//    EnemyHealth enemyHealth;        // Reference to this enemy's health.
//    NavMeshAgent nav;               // Reference to the nav mesh agent.
//    Animator animator;

//    public float moveSpeed = 2f;
//    readonly int interpolation = 10;

//    public bool playerInRange = false;
//    bool walking;

//    void Awake ()
//    {
//        // Set up the references.
//        player = GameObject.FindGameObjectWithTag ("Player").transform;
//        playerHealth = player.GetComponent <PlayerHealth> ();
//        enemyHealth = GetComponent <EnemyHealth> ();
//        nav = GetComponent <NavMeshAgent> ();
//        animator = GetComponent <Animator> ();
//    }

//    void Update ()
//    {
//        // If the enemy and the player have health left...
//        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !playerInRange)
//        {
//            // ... set the destination of the nav mesh agent to the player.
//            nav.enabled = true;
//            nav.speed = moveSpeed / interpolation;
//            if (walking == false)
//            {
//                animator.SetTrigger("Reset");
//            }
//            animator.SetFloat("MoveSpeed", moveSpeed);
//            nav.SetDestination (player.position);
//            walking = true;
//        }
//        // Otherwise...
//        else
//        {
//            walking = false;
//            // ... disable the nav mesh agent.
//            nav.enabled = false;
//        }
//    } 
//}