using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject earth_;
    public float BaseSpeed_;

    private SpriteRenderer cometSprite_;

    private float distanceToEarth_;
    private float currentSpeed_;
    private Vector3 CurrentDir_;
    private Vector3 desiredDir_;
    private float changeDirection_;
    void Start()
    {
        cometSprite_ = GetComponentInChildren<SpriteRenderer>();
        CurrentDir_ = earth_.transform.position - transform.position;
        CurrentDir_.Normalize();
    }

    void Update()
    {
        GoTowards();
        Rotate();
    }

    void GoTowards()
    {
        transform.position += CurrentDir_ * BaseSpeed_ * Time.deltaTime;
    }

    void Rotate()
    {
        Vector3 dir = transform.position - earth_.transform.position;
        Vector3 up = new Vector3(0, 0, 1);
        var rotation = Quaternion.LookRotation(dir, up);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }


}
