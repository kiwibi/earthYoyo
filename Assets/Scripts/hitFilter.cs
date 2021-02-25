using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitFilter : MonoBehaviour
{
    public static hitFilter instance;

    public float duration_;

    public Image[] filters_;


    void Awake()
    {
        instance = this;
    }

    public static void MoonCometHit()
    {
        instance.StartCoroutine(instance.cHit(1));
    }

    public IEnumerator cHit(int index)
    {
        filters_[index].enabled = true;
        yield return new WaitForSeconds(duration_);
        filters_[index].enabled = false;
    }
    public static void CometEarthHit()
    {
        
        instance.StartCoroutine(instance.cHit(0));
    }

    public static void stopAll()
    {
        instance.filters_[0].enabled = false;
        instance.filters_[1].enabled = false;
        instance.transform.GetChild(2).GetComponent<Text>().enabled = true;
    }
}

