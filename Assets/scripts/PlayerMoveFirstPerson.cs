using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveFirstPerson : MonoBehaviour {

	public float speed = 1f;
	public float maxSpeed = 5f;

	Vector3 moveVec;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		float horiz = Input.GetAxis("Horizontal");
		float vert  = Input.GetAxis("Vertical");

		moveVec = new Vector3(horiz, 0f, vert);
	}

	void FixedUpdate () {
		if (rb.velocity.magnitude < maxSpeed) {
			Debug.Log("Moving: " + rb.velocity.magnitude);
			rb.AddRelativeForce(moveVec * Time.fixedDeltaTime * speed);
		}
//		Debug.Log(rb.velocity.magnitude);
	}
}
