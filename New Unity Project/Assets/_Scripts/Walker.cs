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
        duration = curve.segDuration * curve.getNumCurves();
        Debug.Log(duration + " DURATION");

    }

    // Update is called once per frame
    void Update()
    {

        progress += Time.deltaTime;
        float boundedTime = progress % duration;
        Debug.Log(Time.deltaTime +" delta time?");
        Debug.Log(progress + " progress");
        int curveNum = (int)(boundedTime / curve.segDuration);
        Debug.Log(curveNum + " CURVE NUMS");
        Debug.Log(duration + " DURATION");
        //if (progress > 1f)
        //{
        //    progress = 0f;
        //}
        transform.localPosition = curve.EvalBezPoint(progress, curveNum*3);


    }
}
