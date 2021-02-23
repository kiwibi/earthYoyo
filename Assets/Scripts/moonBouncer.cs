using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonBouncer : MonoBehaviour
{
    private GameObject earth_;
    void Start()
    {
        earth_ = GameObject.FindGameObjectWithTag("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = earth_.transform.position;
    }
}
