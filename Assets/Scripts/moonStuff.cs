using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonStuff : MonoBehaviour
{
    public Transform earth_;
    public float pushbackPower_;
    private LineRenderer line_;
    private Transform hand_;
    void Start()
    {
        line_ = GetComponent<LineRenderer>();
        hand_ = earth_.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        line_.SetPosition(0, transform.position);
        line_.SetPosition(1, hand_.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name != "MoonBouncer")
        {
            Destroy(col.gameObject);
        }
        else
        {
            Debug.Log("bounce");
            Vector3 dir = transform.position - earth_.position;
            Vector3 force = dir.normalized * pushbackPower_;
            GetComponent<Rigidbody2D>().AddForce(force);
        }

    }
}
