﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moonStuff : MonoBehaviour
{
    public Transform earth_;
    public GameObject particleSystem_;
    private Transform hand_;
    private AudioSource source_;
    void Start()
    {
        source_ = GetComponent<AudioSource>();
        hand_ = earth_.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name != "MoonBouncer")
        {
            Destroy(col.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 dir = col.transform.position - transform.position;
        dir.Normalize();
        cameraShake.bump(dir);
        if (col.transform.name != "MoonBouncer")
        {
            source_.Play();
            hitFilter.MoonCometHit();
            var prtSystem = Instantiate(particleSystem_, col.transform.position, Quaternion.identity);
            ParticleSystem parts = prtSystem.GetComponent<ParticleSystem>();
            float totalDuration = parts.main.duration + parts.main.startLifetime.constant; 
            Destroy(prtSystem, totalDuration);
        }
        
    }

    
}
