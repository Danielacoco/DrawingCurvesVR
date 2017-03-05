using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class LineScript : MonoBehaviour {

	public LineRenderer lr;
	public Transform p0;
	public Transform p1;
	public int layerOrder = 0;

    //public Vector3 p0, p1;

	// Use this for initialization
	void Start () {
		lr.sortingLayerID = layerOrder;
		
	}
	
	// Update is called once per frame
	void Update () {
		lr.SetPosition (0, p0.position);
		lr.SetPosition (1, p1.position);
		
	}
}
