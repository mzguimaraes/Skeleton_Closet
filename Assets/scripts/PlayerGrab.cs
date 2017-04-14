using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerGrab : MonoBehaviour {

	public Text debug;
	public bool debugModeActive = false;

//	public float pickupRange = 5f;

	private Grabbable objectCarried;
	private Camera cam;

	void Start () {
		cam = Camera.main; //the Tango camera

		if (!debugModeActive)
			debug.gameObject.SetActive(false);
	}

	public Grabbable getObjectCarried() {
		return objectCarried;
	}

	void Update () {
		if (objectCarried == null && Input.touchCount == 1) {
			//on click, attempt to grab an object
			Touch touch = Input.GetTouch(0);

//			debug.text = "detected touch here!";
//			debug.transform.position = touch.position;

			Ray ray = cam.ScreenPointToRay(touch.position);
			RaycastHit rch;
			debug.text = "Shooting raycast";
//			if (Physics.Raycast(transform.position, cam.gameObject.transform.forward, out rch, pickupRange)) {
			if (touch.phase == TouchPhase.Began
				&& Physics.Raycast(ray, out rch)) {

				debug.text += "Raycast hit " + rch.collider.gameObject.name;

				if ( rch.collider.gameObject.GetComponent<Grabbable>() != null 
					&& rch.collider.gameObject.GetComponent<Grabbable>().Interactive) 
				{
					debug.text += "\ntrying to grab " + rch.collider.gameObject.name;
					//component is grabbable and interactive--grab it!
					objectCarried = rch.collider.gameObject.GetComponent<Grabbable>();
					objectCarried.GetComponent<Rigidbody>().isKinematic = true;
					objectCarried.IsBeingHeld = true;
				}
			}
		}
//		else {
//			//throw bone
//			if (Input.GetKeyDown(KeyCode.Mouse0)) {
//				objectCarried.GetComponent<Rigidbody>().isKinematic = false;
//				objectCarried.IsBeingHeld = false;
//				//TODO: figure out how to properly add force to the throw
////				objectCarried.GetComponent<Rigidbody>().AddRelativeForce(cam.transform.forward * 200f);
//				objectCarried = null;
//			}
//		}
		if (objectCarried != null) {
			//if the object stops being interactive, stop carrying it
			if (!objectCarried.Interactive) {
				objectCarried = null;
			}
			else {
				//carry the object in front of the camera
				objectCarried.transform.position = cam.transform.position + cam.transform.forward;
			}
		}
	}
}
