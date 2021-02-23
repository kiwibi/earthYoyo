using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonStuff : MonoBehaviour
{
    public Transform earth_;
    public float pushbackPower_;
    private LineRenderer line_;
    void Start()
    {
        line_ = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line_.SetPosition(0, transform.position);
        line_.SetPosition(1, earth_.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Earth"))
        {
            Debug.Log("not earth");
            Vector3 dir = earth_.position - transform.position;
            Vector3 force = dir.normalized * pushbackPower_;
            GetComponent<Rigidbody2D>().AddForce(force);
            Destroy(col.gameObject);
        }
        else
        {
            Debug.Log("=)");
            Vector3 dir = earth_.position - transform.position;
            Vector3 force = dir.normalized * pushbackPower_;
            GetComponent<Rigidbody2D>().AddForce(force);
        }

    }
}
