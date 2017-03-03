using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : Grabbable {

	public static float proximityRadius = 3f;

	public BoneGoalPosition goalPos;

	// Update is called once per frame
	void Update () {
		//if position is near goal, place it
		if (Vector3.Distance(transform.position, goalPos.transform.position) < proximityRadius) {
			goalPos.insertBone(this);
			Interactive = false;
		}
	}
}
