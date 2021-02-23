using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public float spawnAmount_;
    public float spawnDelay_;

    public GameObject comet_;

    private float spawnTimer_;
    private GameObject[] spawnpoints_;
    void Start()
    {
        spawnpoints_ = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnTimer_ = spawnDelay_;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer_ += Time.deltaTime;

        if(spawnTimer_ >= spawnDelay_)
        {
            spawnComets();
            spawnTimer_ = 0;
        }
    }

    void spawnComets()
    {
        for(int i = 0; i < spawnAmount_; i++)
        {
            Vector3 tmp = spawnpoints_[Random.Range(0, spawnpoints_.Length)].transform.position;
            tmp.z = 0;
            var comet = Instantiate(comet_, tmp, Quaternion.identity);
        }
    }
}
