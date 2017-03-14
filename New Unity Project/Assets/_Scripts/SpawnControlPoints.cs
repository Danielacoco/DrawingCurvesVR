using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlPoints : MonoBehaviour {


    private SteamVR_TrackedObject trackedObj;
    public ControlPoint controlPointPrefab;
    public MyCatmullRomCurve CRcurve;
    public MyBezierCurve BCurve;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
	void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            SpawnPoint();
        }
		
	}

    void SpawnPoint()
    {
        if (CRcurve)
        {
            var controlPoint = Instantiate(controlPointPrefab).GetComponent<ControlPoint>();

            controlPoint.transform.position = trackedObj.transform.position;

            CRcurve.ExtendCurve(controlPoint);
        }

        if (BCurve)
        {
            var controlPoint = Instantiate(controlPointPrefab).GetComponent<ControlPoint>();

            controlPoint.transform.position = trackedObj.transform.position;

            BCurve.ExtendCurve(controlPoint);
        }
        
    }
}
