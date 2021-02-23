using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    private SpriteRenderer cometSprite_;
    public GameObject earth_;
    // Start is called before the first frame update
    void Start()
    {
        cometSprite_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 dir = transform.position - earth_.transform.position;
        Vector3 up = new Vector3(0, 0, 1);
        var rotation = Quaternion.LookRotation(dir, up);
        rotation.x = 0;
        rotation.y = 0;
        cometSprite_.transform.rotation = rotation;
    }
}
