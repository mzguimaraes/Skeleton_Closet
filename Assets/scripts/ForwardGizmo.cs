using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardGizmo : MonoBehaviour {

	public float lineSize = 1f;

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.localPosition, 
			transform.position + new Vector3(0f, transform.localRotation.eulerAngles.y * lineSize, 0f) );
	}
}
