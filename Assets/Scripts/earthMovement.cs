using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthMovement : MonoBehaviour
{
    public float smoothSpeed = 0.05f;
    public Vector3 offset_;
    
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
