using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TapPrompt : MonoBehaviour {

//	public bool isTapped = false;

//	public TextMesh text;
//	Color textColor;

//	public Text debug;

	TextMesh text;

	PlayerGrab playerGrabScript;

//	bool hasPickedUpBone = false;

	//BoneGoalPosition boneGoalScript;

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
//		textColor = GetComponent<TextMesh>().color;
		playerGrabScript = GameObject.FindObjectOfType<PlayerGrab>();
	//	boneGoalScript = GameObject.Find ("BoneGoalPosition").GetComponent<BoneGoalPosition> ();
	}

	IEnumerator FadeOut() {
		float alpha = text.color.a;
		while (alpha > 0f) {
			alpha = Mathf.Lerp(alpha, 0f, .025f);
			text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
			yield return null;
		}
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerGrabScript.isCarryingObject) {
//			debug.text = "picked up object";
//			hasPickedUpBone = true;
			StartCoroutine(FadeOut());

//			gameObject.SetActive(false);
//			textColor.a = 0;
//			this.GetComponent<MeshRenderer> ().material.color = textColor;
		}
//		else {
//			textColor.a = 255f;
//			this.GetComponent<MeshRenderer> ().material.color = textColor;
//		}

	}
}
