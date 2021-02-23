using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public float G;
    public float minDistance_;
    public float maxDistance_;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        cometBehaviour[] attractors = FindObjectsOfType<cometBehaviour>();
        foreach (cometBehaviour attractor in attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }
    void Attract(cometBehaviour objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        if(distance > minDistance_ && distance < maxDistance_)
        {
            rbToAttract.AddForce(force);
        }
    }
}
