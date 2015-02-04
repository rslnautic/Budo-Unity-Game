using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {
		
	public static float xMovementP1;
	public static bool jumpP1;
	public static float xAimP1;
	public static float yAimP1;


	readonly KeyCode leftP1 = KeyCode.A;
	readonly KeyCode rightP1 = KeyCode.D;
	readonly KeyCode jumpsP1 = KeyCode.W;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (leftP1) && Input.GetKey (rightP1)) {
			xMovementP1 = 0;
		} else if (Input.GetKey (leftP1)) {
			xMovementP1 = -1;
		} else if (Input.GetKey (rightP1)) {
			xMovementP1 = 1;
		} else {
			xMovementP1 = 0;
		}

		if (Input.GetKey (jumpsP1)) {
			jumpP1 = true;
		} else {
			jumpP1 = false;
		}
	}
}
