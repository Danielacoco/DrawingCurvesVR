using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBezierCurve : MonoBehaviour {

	public Transform[] controlPoints;
	public LineRenderer lineRenderer;
//	public Matrix4x4 basisMatrix = new Matrix4x4 {-1, 3, -3, 1,
//		3, -6, 3, 0, 
//		-3, 3, 0, 0, 
//		1, 0, 0, 0
//	};

	private int numCurves = 0;
	private int layerOrder = 0;
	private int numSegments = 50;

	// Use this for initialization
	void Start () {
		if (!lineRenderer){
			lineRenderer = GetComponent<LineRenderer>();
		}
		lineRenderer.sortingOrder = layerOrder;
		numCurves = (int)controlPoints.Length / 3;
		//DrawCurve ();
	}
	
	// Update is called once per frame
	void Update () {

		DrawCurve ();
	}

	void DrawCurve(){
		int start = 0;
		for (int i = 0; i < numCurves; i++) {
			
			for (int seg = 1; seg <= numSegments; seg++) {
				float time = seg / (float)numSegments;
                start = i * 3;
                //Debug.Log(time);
                //Debug.Log(" time");

				Vector3 point = EvalBezierPoint (time, controlPoints[start].position, controlPoints [start + 1].position, controlPoints [start + 2].position, controlPoints [start + 3].position);
                lineRenderer.numPositions = (i * numSegments) + seg;
                //Debug.Log(lineRenderer.numPositions);
                //Debug.Log(i * numSegments + (seg - 1));
				lineRenderer.SetPosition ((i * numSegments) + (seg - 1), point);

			}
		}
	}

	Vector3 EvalBezierPoint ( float time, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4){
//		Matrix4x4 geomMatrix = new Matrix4x4 {p1 [0], p1 [1], p1 [2], 1,
//			p2 [0], p2 [1], p2 [2], 1,
//			p3 [0], p3 [1], p3 [2], 1,
//			p3 [0], p3 [1], p3 [2], 1
//		};
//
//		Vector4 T = new Vector4{ time * time * time, time * time, time, 1 };
//
//		Vector4 result = T * (basisMatrix * geomMatrix);
//
//		return new Vector3{ result [0], result [1], result [2] };

		float oneMinT = 1f - time;

       return oneMinT*oneMinT*oneMinT * p1 + 3f * oneMinT * oneMinT * time * p2 + 3f * oneMinT * time * time * p3 + time * time * time * p4;


		//return (3f * oneMinT * oneMinT * (p2 - p1) +
		//	6f * oneMinT * time * (p3 - p2) +
		//	3f * time * time * (p4 - p3));

	}
}
