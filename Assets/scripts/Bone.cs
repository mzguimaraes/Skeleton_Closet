﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(MeshCollider))]
public class Bone : Grabbable {

	public List<string> hints;
	private float heldTimer = 0f;

	public BoneGoalPosition goalPos;

	void Start() {
		GetComponent<MeshCollider>().convex = true;
	}

	public float getHeldTimer() {
		return heldTimer;
	}


	// Update is called once per frame
	void Update () {
		//if position is near goal, place it
		if (Vector3.Distance(transform.position, goalPos.transform.position) < goalPos.proximityRadius) {
			goalPos.insertBone(this);
			Interactive = false;
		}

		//if being held, increment timer
		if (IsBeingHeld) {
			heldTimer += Time.deltaTime;
		}
	}
}
