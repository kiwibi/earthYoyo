using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFollow : MonoBehaviour
{
    public float smoothSpeed;
    public float bgrDivider_;

    private GameObject earth_;
    private void Start()
    {
        earth_ = GameObject.FindGameObjectWithTag("Earth");
    }
    private void FixedUpdate()
    {
        Vector3 desired = new Vector3((earth_.transform.position.x / bgrDivider_) * -1, (earth_.transform.position.y / bgrDivider_) * -1, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desired, smoothSpeed);
        transform.position = smoothedPosition;
    }
    private void Update()
    {
       
    }
}
