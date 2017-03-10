using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

	public float pickupRange = 5f;

	private Grabbable objectCarried;
	private Camera cam;

	void Start () {
		cam = GetComponentInChildren<Camera>();
	}

	void Update () {
		if (objectCarried == null && Input.GetKeyDown(KeyCode.Mouse0)) {
			//on click, attempt to grab an object
			RaycastHit rch;
			if (Physics.Raycast(transform.position, cam.gameObject.transform.forward, out rch, pickupRange)) {
				if (rch.collider != null 
					&& rch.collider.gameObject.GetComponent<Grabbable>() != null 
					&& rch.collider.gameObject.GetComponent<Grabbable>().Interactive) 
				{
					//component is grabbable and interactive--grab it!
					objectCarried = rch.collider.gameObject.GetComponent<Grabbable>();
					objectCarried.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		}
		else {
			//throw bone
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				objectCarried.GetComponent<Rigidbody>().isKinematic = false;
				//TODO: figure out how to properly add force to the throw
//				objectCarried.GetComponent<Rigidbody>().AddRelativeForce(cam.transform.forward * 200f);
				objectCarried = null;
			}
		}
		if (objectCarried != null) {
			//if the object stops being interactive, stop carrying it
			if (!objectCarried.Interactive) {
				objectCarried = null;
			}
			else {
				//carry the object in front of the camera
				objectCarried.transform.position = cam.transform.position + cam.transform.forward * 2f;
			}
		}

	}
}
