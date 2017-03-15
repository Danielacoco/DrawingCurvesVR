using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public MyBezierCurve curve;

    private float duration;

    private float progress;

    // Use this for initialization
    void Start()
    {
        
        Debug.Log(duration + " DURATION");

    }

    // Update is called once per frame
    void Update()
    {
        duration = curve.segDuration * curve.getNumCurves();
        progress += Time.deltaTime;
        float boundedTime = progress % duration;
        Debug.Log(Time.deltaTime +" delta time?");
        Debug.Log(progress + " progress");
        Debug.Log(boundedTime + "bounded time");
        int curveNum = (int)(boundedTime / curve.segDuration);

        float timeParam = (boundedTime - curveNum * curve.segDuration) / curve.segDuration;
        Debug.Log(curveNum + " CURVE NUMS");
        Debug.Log(timeParam + "time parammmmmm");
        Debug.Log(duration + " DURATION");
        //if (progress > 1f)
        //{
        //    progress = 0f;
        //}
        transform.localPosition = curve.EvalBezPoint(timeParam, curveNum*3);


    }
}
