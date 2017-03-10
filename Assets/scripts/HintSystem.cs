using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HintSystem : MonoBehaviour {
	public Text hintText;
	public float hintDelta = 3f; //time between subsequent hint displays

	private PlayerGrab player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerGrab>();
		hintText.text = "";
	}

	string buildHintString(Bone bone) {
		string hintString = "";
		for (int i = 0; i < bone.hints.Count; i ++) {
			if (bone.getHeldTimer() > (i + 1) * hintDelta) {
				hintString += bone.hints[i];
				hintString += "\n";
			}
			else {
				//if a given hint is not being displayed, neither should the subsequent hints
				break;
			}
		}
		return hintString;
	}

	// Update is called once per frame
	void Update () {
		Grabbable objectCarried = player.getObjectCarried();
		if (objectCarried != null) {
			Bone bone = objectCarried.GetComponent<Bone>();
			if (bone != null) {
				hintText.text = buildHintString(bone);
			}
		}
		else {
			hintText.text = "";
		}
	}
}
