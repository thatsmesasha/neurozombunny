//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class LightningSpell : Spell
//{
//    public GameObject shootAnimation;
//    public Mesh activeMesh;
//    public Mesh notActiveMesh;

//    MeshFilter meshFilter;

//    RaycastResult raycastResult;
//    const float animationLength = 10f;
//    const float animationSpeed = 4f;

//    bool wasActive;

//    // Start is called before the first frame update
//    void Start()
//    {
//        InitInputDevice();
//        meshFilter = GetComponent<MeshFilter>();
//        wasActive = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        UpdateTimer();
//        if (IsActive() && !wasActive)
//        {
//            meshFilter.mesh = activeMesh;
//        }
//        else if (wasActive && !IsActive())
//        {
//            meshFilter.mesh = notActiveMesh;
//        }
//        wasActive = IsActive();
//        if (IsCasting())
//        {
//            Cast();
//        }
//    }

//    void Cast()
//    {
//        ResetTimer();
//        raycastResult = GvrPointerInputModule.CurrentRaycastResult;
//        if(raycastResult.isValid)
//        {
//            EnemyHealth enemyHealth = raycastResult.gameObject.GetComponent <EnemyHealth> ();
//            if(enemyHealth != null)
//            {
//                enemyHealth.TakeDamage(damage, raycastResult.worldPosition, raycastResult.worldNormal);
//            }
//            CastAnimation(raycastResult.distance);
//        }
//        else
//        {
//            CastAnimation(animationLength);
//        }
//    }

//    void CastAnimation(float length)
//    {
//        Vector3 position = shootingStart.transform.position;
//        Quaternion rotation = Quaternion.LookRotation(shootingEnd.transform.position - shootingStart.transform.position);
//        GameObject firedAnimation = Instantiate(shootAnimation, position, rotation);
//        ParticleSystem particles = firedAnimation.GetComponent<ParticleSystem>();
//        particles.playbackSpeed = animationSpeed;
//        particles.Emit(1);
//        float totalDuration = particles.duration;
//        firedAnimation.transform.position = position;
//        firedAnimation.transform.rotation = rotation;
//        firedAnimation.transform.localScale = new Vector3(0.2f, 0.2f, length / animationLength);
//        Destroy(firedAnimation, totalDuration / animationSpeed);
//    }
//}
