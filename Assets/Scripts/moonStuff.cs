using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonStuff : MonoBehaviour
{
    public Transform earth_;

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
}
