
using UnityEngine;

public class BoneGoalPosition : MonoBehaviour {
	//put this on a GameObject to give a Bone its goal Transform

	public float proximityRadius = 1f;

	private PlayerGrab player; //to activate Goal Glow
	private bool bonePlaced = false;
	private Light goalGlow;

	void Start () {
		player = GameObject.FindObjectOfType<PlayerGrab>();
		goalGlow = GetComponent<Light>();
		goalGlow.enabled = false;
	}

	void Update () {
		if (!bonePlaced && player.isCarryingObject) {
			goalGlow.enabled = true;
		}
		else {
			goalGlow.enabled = false;
		}
	}

	public void insertBone(Bone bone) {
		bone.gameObject.transform.position = transform.position;
		bone.gameObject.transform.rotation = transform.rotation;
		bone.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		bone.IsBeingHeld = false;
		bonePlaced = true;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, Vector3.one * proximityRadius);
		//TODO: make this gizmo bone-shaped
//		Gizmos.DrawMesh(boneMesh);
	}
}
