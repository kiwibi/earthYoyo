using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject earth_;
    public float BaseSpeed_;

    private SpriteRenderer cometSprite_;

    private float distanceToEarth_;
    private float currentSpeed_;
    private Vector3 CurrentDir_;
    private Vector3 desiredDir_;
    private float changeDirection_;
    private Rigidbody2D rb_;
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        earth_ = GameObject.FindGameObjectWithTag("Earth");
        cometSprite_ = GetComponentInChildren<SpriteRenderer>();
        CurrentDir_ = earth_.transform.position - transform.position;
        CurrentDir_.Normalize();
        CurrentDir_.z = 0;
        rb_.AddForce(CurrentDir_ * BaseSpeed_);
    }

    void Update()
    {
        Rotate();
    }

    void GoTowards()
    {
        transform.position += CurrentDir_ * BaseSpeed_ * Time.deltaTime;
    }

    void Rotate()
    {
        if(rb_.velocity != Vector2.zero)
        {
            Vector3 up = new Vector3(0, 0, 1);
            var rotation = Quaternion.LookRotation(rb_.velocity, up);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = rotation;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "moon")
        {
            Destroy(gameObject, 3);
        }
    }

}
