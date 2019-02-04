using UnityEngine;
using System.Collections.Generic;
using EnemyHelper;
using UnityEngine.EventSystems;

public class FrostBlast : MonoBehaviour, IWeapon
{
    public float damagePerShot = 0.1f;
    public float range = 150f;
    public float timeBetweenFireDamage = 0.25f;
    public EnemyType shootableEnemytype;


    ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> collisionEvents;


    //Ray shootRay;
    //RaycastHit shootHit;

    GameObject shootingStart;

    GvrControllerInputDevice inputDevice;

    bool wasCasting;

    //float timer;


    void Awake()
    {
        inputDevice = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);

        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        shootingStart = GameObject.FindGameObjectWithTag("ShootingStart");

    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        if (inputDevice.GetButton(GvrControllerButton.TouchPadButton))
        {
            if (!wasCasting)
            {
                wasCasting = true;
                particleSystem.Play();
            }
            //if (timer >= timeBetweenFireDamage)
            //{
            //    Shoot();
            //}
        }
        else
        {
            if (wasCasting)
            {
                particleSystem.Stop();
            }
            wasCasting = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("hot!");
        particleSystem.GetCollisionEvents(other, collisionEvents);
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.type == shootableEnemytype)
        {
            enemyHealth.TakeDamage(damagePerShot, collisionEvents[0].intersection);
        }
    }

    //void Shoot()
    //{
    //    timer = 0f;

    //    shootRay.origin = shootingStart.transform.position;
    //    shootRay.direction = shootingStart.transform.forward;

    //    if (Physics.Raycast(shootRay, out shootHit, range))
    //    {
    //        Debug.Log("shoot");
    //        EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
    //        if (enemyHealth != null && enemyHealth.type == shootableEnemytype)
    //        {
    //            enemyHealth.TakeDamage(damagePerShot, shootHit.point);
    //        }
    //    }
    //}

    public bool IsAvailable()
    {
        return true;
    }

    public EnemyType GetShootableEnemyType()
    {
        return shootableEnemytype;
    }
}
