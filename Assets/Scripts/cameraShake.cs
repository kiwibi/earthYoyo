using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    private float camSize;
    private Vector3 originalPos;
    public static cameraShake instance;                                                                                          
    private Camera MainCam;
    private Coroutine LastCoroutine;

    public static bool isShaking;

    public float shakeDuration_;
    public float zoomShake_;

    public float bumpDuration_;


    void Awake()
    {
        originalPos = transform.position;
        instance = this;                                                                                                                  
        cameraShake.isShaking = false;                                                                                                 
        MainCam = Camera.main;                                                                                                     

    }

    public static void Shake()
    {
        cameraShake.isShaking = true;                                                                                                   
        instance.camSize = Camera.main.orthographicSize;                                                                                   
        instance.LastCoroutine = instance.StartCoroutine(instance.cShake());                                                         
    }

    public static void bump(Vector3 dir)
    {
        cameraShake.isShaking = true;
        instance.LastCoroutine = instance.StartCoroutine(instance.cBump(dir));
    }
    public IEnumerator cBump(Vector3 dir)
    {
        float endTime = Time.time + bumpDuration_;
        while (Time.time < endTime)
        {

            transform.position += dir * Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
        cameraShake.isShaking = false;
    }
    public IEnumerator cShake()
    {
        float endTime = Time.time + shakeDuration_;                                                                                           

        while (Time.time < endTime)                                                                                               
        {
            float sizeChange = Random.Range(zoomShake_, 5.0f);                                                        
            
            MainCam.orthographicSize = sizeChange;                                                                                              

            yield return null;                                                                                                           
        }

        MainCam.orthographicSize = camSize;                                                                                           
        cameraShake.isShaking = false;                                                                                              
    }

    public static void StopShake()
    {
        if (instance.LastCoroutine == null)
            return;
        instance.StopCoroutine(instance.LastCoroutine);
        
        instance.MainCam.orthographicSize = instance.camSize;                                                                                          
        cameraShake.isShaking = false;
    }
}
