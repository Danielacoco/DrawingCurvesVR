using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorate : MonoBehaviour {

    public MyBezierCurve curve;

    public int frequency;

    public Transform[] decors;


    private void Awake()
    {
        if (frequency <=0 || decors == null || decors.Length == 0)
        {
            return;
        }
        float step = 1f / (frequency * decors.Length);
        for (int x = 0, f = 0; f< frequency; f++)
        {
            for (int i = 0; i < decors.Length; i++, x++)
            {
                Transform decor = Instantiate(decors[i]) as Transform;
                Vector3 pos = curve.EvalBezPoint(x * step, 0);
                decor.transform.localPosition = pos;
                decor.transform.parent = curve.transform;
            }
        }
    }
}
