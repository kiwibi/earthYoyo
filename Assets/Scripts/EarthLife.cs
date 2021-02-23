﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthLife : MonoBehaviour
{
    public float AmountOfLives_;

    public GameObject bandAid_;

    private float bandAidAccumulator_;
    private GameObject earth_;
    private float earthScale_;
    void Start()
    {
        earth_ = GameObject.FindGameObjectWithTag("Earth");
        bandAidAccumulator_ = 0;
        earthScale_ = earth_.transform.GetChild(0).localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    Vector3 getSpawnOnEarth()
    {
        var easy = earth_.transform.position;
        Vector3 tmp = Random.insideUnitCircle * earthScale_;
        Vector3 ReturnVector = new Vector3(easy.x + tmp.x, easy.y + tmp.y);
        return ReturnVector;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name != "moon")
        {
            Destroy(col.gameObject);
            AmountOfLives_--;
            bandAidAccumulator_++;
            if(bandAidAccumulator_ >= 3)
            {
                Instantiate(bandAid_, getSpawnOnEarth(),Quaternion.identity, earth_.transform.GetChild(0));
            }
        }
    }
}
