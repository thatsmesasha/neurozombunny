﻿using UnityEngine;
using System.Collections.Generic;
using EnemyHelper;

public class DestroyOnParticleSystemEnd : MonoBehaviour
{
    ParticleSystem particleSystem;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particleSystem)
        {
            if (!particleSystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
