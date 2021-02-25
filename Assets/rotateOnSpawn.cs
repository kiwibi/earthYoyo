using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateOnSpawn : MonoBehaviour
{
    
    void Start()
    {
        var rotation = Random.rotation;
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
