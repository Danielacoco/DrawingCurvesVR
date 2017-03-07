using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public MyBezierCurve curve;

    public float duration;

    private float progress;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        progress += Time.deltaTime / duration;
        if (progress > 1f)
        {
            progress = 0f;
        }
        transform.localPosition = curve.EvalBezPoint(progress, 0);


    }
}
