using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public float initialSpawnAmount_;
    public float upgradeAmount_;
    public float spawnDelay_;
    public float upgradeTime_;

    public GameObject parent_;
    public GameObject comet_;

    private float spawnTimer_;
    private float currentSpawnAmount_;
    private float upgradeTimer_;
    private GameObject[] spawnpoints_;
    void Start()
    {
        spawnpoints_ = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnTimer_ = spawnDelay_;
        upgradeTimer_ = 0;
        currentSpawnAmount_ = initialSpawnAmount_;
    }

    // Update is called once per frame
    void Update()
    {
        upgradeTimer_ += Time.deltaTime;
        if(upgradeTimer_ >= upgradeTime_)
        {
            currentSpawnAmount_ += upgradeAmount_;
            if (currentSpawnAmount_ > spawnpoints_.Length - 1)
            {
                currentSpawnAmount_ = spawnpoints_.Length - 1;

            }
            upgradeTimer_ = 0;

        }
        spawnTimer_ += Time.deltaTime;
        if (spawnTimer_ >= spawnDelay_)
        {
            spawnComets();
            spawnTimer_ = 0;
        }
    }

    void spawnComets()
    {
        float[] choosenSpawnPoints;
        for(int i = 0; i < currentSpawnAmount_; i++)
        {
            Vector3 tmp = spawnpoints_[Random.Range(0, spawnpoints_.Length)].transform.position;
            tmp.z = 0;
            var comet = Instantiate(comet_, tmp, Quaternion.identity, parent_.transform);
        }
    }
}
