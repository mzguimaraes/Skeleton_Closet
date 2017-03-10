
using UnityEngine;

public class BoneGoalPosition : MonoBehaviour {
	//put this on a GameObject to give a Bone its goal Transform

//	public Mesh boneMesh; //mesh of bone assigned to this goal

	public void insertBone(Bone bone) {
		bone.gameObject.transform.position = transform.position;
		bone.gameObject.transform.rotation = transform.rotation;
		bone.gameObject.GetComponent<Rigidbody>().isKinematic = true;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
		//TODO: make this gizmo bone-shaped
//		Gizmos.DrawMesh(boneMesh);
	}
}
