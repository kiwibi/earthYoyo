using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMovement : MonoBehaviour
{

    public GameObject earth_;
    public float BaseSpeed_;

    private float distanceToEarth_;
    private float currentSpeed_;
    private Vector3 CurrentDir_;
    private float changeDirection_;
    private SpringJoint2D spring_;
    void Start()
    {
        spring_ = GetComponent<SpringJoint2D>();
    }



   
    
    
}
