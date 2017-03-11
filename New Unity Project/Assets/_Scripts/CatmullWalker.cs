using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullWalker : MonoBehaviour {


    public MyCatmullRomCurve curve;

    public float duration;

    private float progress;

    // Use this for initialization
    void Start()
    {
        duration = curve.segDuration * curve.controlPoints.Length - 1;

    }

    // Update is called once per frame
    void Update()
    {

        progress += Time.deltaTime / duration;
        if (progress > 1f)
        {
            progress = 0f;
        }
        transform.localPosition = curve.EvalCurvePoint(progress, 0, 3);


    }
}
