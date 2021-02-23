using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    private float camSize;                                                                                                                 
    public static cameraShake instance;                                                                                          
    private Camera MainCam;
    private Coroutine LastCoroutine;

    public static bool isShaking;

    public enum ShakeTypes
    {
        METEORCRASH,

    }

    void Awake()
    {
        instance = this;                                                                                                                  
        cameraShake.isShaking = false;                                                                                                 
        MainCam = Camera.main;                                                                                                     

    }

    public static void Shake(float duration, ShakeTypes type)
    {
        cameraShake.isShaking = true;                                                                                                   
        instance.camSize = Camera.main.orthographicSize;                                                                                   
        instance.LastCoroutine = instance.StartCoroutine(instance.cShake(duration, type));                                                         
    }

    public IEnumerator cShake(float duration, ShakeTypes type)
    {
        switch(type)
        {
            case ShakeTypes.METEORCRASH:
                break;
        }
        float endTime = Time.time + duration;                                                                                           

        while (Time.time < endTime)                                                                                               
        {
            float sizeChange = Random.Range(4.5f, 5.0f);                                                        
            
            MainCam.orthographicSize = sizeChange;
            
            duration -= Time.deltaTime;                                                                                               

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
