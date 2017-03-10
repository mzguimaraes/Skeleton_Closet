using UnityEngine;

public class Grabbable : MonoBehaviour {
	//can be picked up by PlayerGrab

	private bool interactive = true;
	public  bool Interactive {
		get {
			return interactive;
		}
		protected set {
			interactive = value;
		}
	}

	//TODO: add protections to set
	private bool isBeingHeld = false;
	public  bool IsBeingHeld {
		get {
			return isBeingHeld;
		}
		set {
			isBeingHeld = value;
		}
	}
}
