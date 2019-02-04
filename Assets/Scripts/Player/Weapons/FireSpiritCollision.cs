using UnityEngine;
using System.Collections.Generic;
using EnemyHelper;

public class FireSpiritCollision : MonoBehaviour
{
    public float damagePerShot = 1f;
    public EnemyType shootableEnemytype;

    ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> collisionEvents;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("hot!");
        particleSystem.GetCollisionEvents(other, collisionEvents);
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.type == shootableEnemytype)
        {
            enemyHealth.TakeDamage(damagePerShot, collisionEvents[0].intersection);
            Destroy(gameObject);
        }
    }
}
