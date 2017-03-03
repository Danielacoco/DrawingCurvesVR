using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private GameObject collidingObject;

	private GameObject holdingObject;

	private SteamVR_Controller.Device Controller{
		get {return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

	void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	public void OnTriggerEnter(Collider other){
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other){
		SetCollidingObject (other);
	}
	public void OnTriggerExit(Collider other){
		if (!collidingObject) {
			return;
		}
		collidingObject = null;
	}

	//Grabbing an object

	private void



}
