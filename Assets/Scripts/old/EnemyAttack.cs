//using UnityEngine;
//using System.Collections;

//public class EnemyAttack : MonoBehaviour
//{
//    public float timeBetweenAttacks = 2f;     // The time in seconds between each attack.
//    public int attackDamage = 1;               // The amount of health taken away per attack.
//    public float distanceToAttack = 2f;

//    Animator anim;                              // Reference to the animator component.
//    GameObject player;                          // Reference to the player GameObject.
//    PlayerHealth playerHealth;                  // Reference to the player's health.
//    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
//    EnemyMovement enemyMovement;                // Reference to this enemy's movement.
//    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
//    float timer;                                // Timer for counting up to the next attack.


//    void Awake ()
//    {
//        // Setting up the references.
//        player = GameObject.FindGameObjectWithTag ("Player");
//        playerHealth = player.GetComponent <PlayerHealth> ();
//        enemyHealth = GetComponent<EnemyHealth>();
//        enemyMovement = GetComponent<EnemyMovement>();
//        anim = GetComponent <Animator> ();
//    }


//    void Update ()
//    {
//        if (Vector3.Distance(transform.position, player.transform.position) <= distanceToAttack)
//        {
//            playerInRange = true;
//            enemyMovement.playerInRange = true;
//        }
//        else
//        {
//            playerInRange = false;
//            enemyMovement.playerInRange = false;
//        }

//        // Add the time since Update was last called to the timer.
//        timer += Time.deltaTime;

//        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
//        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
//        {
//            // ... attack.
//            Attack ();
//        }


//        // If the player has zero or less health...
//        // if(playerHealth.currentHealth <= 0)
//        // {
//        //     // ... tell the animator the player is dead.
//        //     anim.SetTrigger ("PlayerDead");
//        // }
//    }

//    void DamagePlayer()
//    {
//        playerHealth.TakeDamage(attackDamage);
//    }

//    void Attack ()
//    {
//        // Reset the timer.
//        timer = 0f;

//        // If the player has health to lose...
//        if(playerHealth.currentHealth > 0)
//        {
//            // ... damage the player.
//            anim.SetTrigger("Attack");
//            Invoke("DamagePlayer", 0.5f);
//        }
//    }
//}