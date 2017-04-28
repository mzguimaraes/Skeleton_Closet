using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPrompt : MonoBehaviour {

	public bool isTapped = false;

	public TextMesh text;
	Color textColor;

	PlayerGrab playerGrabScript;

	bool hasPickedUpBone = false;

	//BoneGoalPosition boneGoalScript;

	// Use this for initialization
	void Start () {
		textColor = this.GetComponent<MeshRenderer> ().material.color;
		playerGrabScript = GameObject.Find ("PlayerGrab").GetComponent<PlayerGrab> ();
	//	boneGoalScript = GameObject.Find ("BoneGoalPosition").GetComponent<BoneGoalPosition> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerGrabScript.isCarryingObject) {
			hasPickedUpBone = true;
			textColor.a = 0;
			this.GetComponent<MeshRenderer> ().material.color = textColor;
		}
//		else {
//			textColor.a = 255f;
//			this.GetComponent<MeshRenderer> ().material.color = textColor;
//		}

	}
}
