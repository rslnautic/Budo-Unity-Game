using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {
		
	 static float xMovementP1;
	 static bool jumpP1;
	 static float xAimP1;
	 static float yAimP1;
	 static bool shootingP1;

	 static float xMovementP2;
	 static bool jumpP2;
	 static float xAimP2;
	 static float yAimP2;
	 static bool shootingP2;


	static public float ejeX1;
	static public float ejeY1;
	static public float ejeXDisparo1, ejeYDisparo1;

	static public float ejeX2;
	static public float ejeY2;
	static public float ejeXDisparo2, ejeYDisparo2;



	readonly KeyCode leftP1 = KeyCode.A;
	readonly KeyCode rightP1 = KeyCode.D;
	readonly KeyCode jumpsP1 = KeyCode.W;
	readonly KeyCode shootP1 = KeyCode.Space;


	readonly KeyCode leftP2 = KeyCode.H;
	readonly KeyCode rightP2 = KeyCode.K;
	readonly KeyCode jumpsP2 = KeyCode.U;
	readonly KeyCode shootP2 = KeyCode.L;

	// Use this for initialization
	void Start () {
	
	}

	public static float GetPlayerXMovement(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return xMovementP1;
			break;
		case Personaje.Pjs.PJ2:
			return xMovementP2;
			break;
		default:
			return 0;
			break;
		}
	
	}

	public static bool GetPlayerJump(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return jumpP1;
			break;
		case Personaje.Pjs.PJ2:
			return jumpP2;
			break;
		default:
			return false;
			break;
		}
		
	}

	public static bool GetPlayerShooting(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return shootingP1;
			break;
		case Personaje.Pjs.PJ2:
			return shootingP2;
			break;
		default:
			return false;
			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		//P1
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

		if (Input.GetKey (shootP1)) {
			shootingP1 = true;
		} else {
			shootingP1 = false;
		}


		//P2
		if (Input.GetKey (leftP2) && Input.GetKey (rightP2)) {
			xMovementP2 = 0;
		} else if (Input.GetKey (leftP2)) {
			xMovementP2 = -1;
		} else if (Input.GetKey (rightP2)) {
			xMovementP2 = 1;
		} else {
			xMovementP2 = 0;
		}
		
		if (Input.GetKey (jumpsP2)) {
			jumpP2 = true;
		} else {
			jumpP2 = false;
		}

		//P1
		if (Input.GetKey (shootP1)) {
			shootingP2 = true;
		} else {
			shootingP2 = false;
		}

		//P2
		if (Input.GetKey (shootP2)) {
			shootingP2 = true;
		} else {
			shootingP2 = false;
		}


		ejeX1 = Input.GetAxis ("HorizontalJoyStick1");
		ejeY1 = Input.GetAxis ("Vertical");
		//ejeXDisparo1 = Input.GetAxis ("HorizontalAim1");
		//ejeYDisparo1 = Input.GetAxis ("VirtualAim1");

		ejeX2 = Input.GetAxis ("HorizontalJoyStick2");
		ejeY2 = Input.GetAxis ("Vertical");
		//ejeXDisparo2 = Input.GetAxis ("HorizontalAim2");
		//ejeYDisparo2 = Input.GetAxis ("VerticalAim2");

		if (Input.GetAxis ("Jump1") == 1) {
			jumpP1 = true;
		} else {
			jumpP1 = false;
		}

		if (Input.GetAxis ("Shoot1") == 1) {
			shootingP1 = true;
		} else {
			shootingP1 = false;
		}

		if (Input.GetAxis ("Jump2") == 1) {
			jumpP2 = true;
		} else {
			jumpP2 = false;
		}
		
		if (Input.GetAxis ("Shoot2") == 1) {
			shootingP2 = true;
		} else {
			shootingP2 = false;
		}
		//bool jumpesito = Input.GetAxis ("Jump");

		xMovementP1 = Mathf.Clamp (ejeX1,-1,1);

		xMovementP2 = Mathf.Clamp (ejeX2,-1,1);

	}
}
