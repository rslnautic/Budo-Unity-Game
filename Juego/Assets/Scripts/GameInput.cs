using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {
		
	 static float xMovementP1;
	 static bool jumpP1;
	 static bool shootingP1;

	 static float xMovementP2;
	 static bool jumpP2;
	 static bool shootingP2;


	static public float ejeX1;
	static public float ejeY1;

	static public float ejeX2;
	static public float ejeY2;


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
		ejeX1 = Input.GetAxis ("Horizontal1");
		xMovementP1 = Mathf.Clamp (ejeX1,-1,1);
		ejeX2 = Input.GetAxis ("Horizontal2");
		xMovementP2 = Mathf.Clamp (ejeX2,-1,1);

		if (Input.GetButton ("Jump1")) {
			jumpP1 = true;
		} else {
			jumpP1 = false;
		}

		if (Input.GetButton ("Shoot1")) {
			shootingP1 = true;
		} else {
			shootingP1 = false;
		}

		if (Input.GetButton ("Jump2")) {
			jumpP2 = true;
		} else {
			jumpP2 = false;
		}
		
		if (Input.GetButton ("Shoot2")) {
			shootingP2 = true;
		} else {
			shootingP2 = false;
		}
	}
}
