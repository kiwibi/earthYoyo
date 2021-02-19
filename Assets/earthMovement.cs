using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthMovement : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }
}
