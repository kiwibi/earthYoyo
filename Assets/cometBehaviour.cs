using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometBehaviour : MonoBehaviour
{
    public GameObject earth_;
    public float BaseSpeed_;

    private float distanceToEarth_;
    private float currentSpeed_;
    private Vector3 CurrentDir_;
    private Vector3 desiredDir_;
    private float changeDirection_;
    void Start()
    {
        GetNewDirection();
        changeDirection_ = 0;
        desiredDir_ = earth_.transform.position;
        CurrentDir_ = new Vector3(Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f), 0);
        Debug.Log(CurrentDir_);
    }

    void Update()
    {
        GoTowards();
        if (Input.GetKey(KeyCode.Space))
        {
            CurrentDir_ = new Vector3(Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f), 0);
            Debug.Log(CurrentDir_);
        }
        if (Input.GetKey(KeyCode.M))
        {
            GetNewDirection();
        }
    }

    void GoTowards()
    {
        distanceToEarth_ = Vector3.Distance(earth_.transform.position, transform.position);
        currentSpeed_ = BaseSpeed_ * distanceToEarth_;
        //transform.Translate(CurrentDir_ * currentSpeed_ * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, desiredDir_, currentSpeed_ * Time.deltaTime);
        GetNewDirection();
    }

    void GetNewDirection()
    {
        changeDirection_ += Time.deltaTime;
        if (changeDirection_ > 0.5f)
        {
            desiredDir_ = earth_.transform.position;
            changeDirection_ = 0;
        }

    }


}
