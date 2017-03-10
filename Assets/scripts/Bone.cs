using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : Grabbable {

	public float proximityRadius = 3f;

	public List<string> hints;
	private float heldTimer = 0f;

	public BoneGoalPosition goalPos;

	public float getHeldTimer() {
		return heldTimer;
	}


	// Update is called once per frame
	void Update () {
		//if position is near goal, place it
		if (Vector3.Distance(transform.position, goalPos.transform.position) < proximityRadius) {
			goalPos.insertBone(this);
			Interactive = false;
		}

		//if being held, increment timer
		if (IsBeingHeld) {
			heldTimer += Time.deltaTime;
		}
	}
}
