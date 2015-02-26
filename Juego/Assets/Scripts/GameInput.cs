using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {
		
	static float xMovementP1;
	static float xAimP1;
	static float yAimP1;
	static bool jumpP1;
	static bool shootingP1;

	static float xMovementP2;
	static float xAimP2;
	static float yAimP2;
	static bool jumpP2;
	static bool shootingP2;
	
	void Update () {
		setXmovent ();
		setJump ();
		setShoot ();
		setRX ();
		setRY ();
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
	
	public static void setXmovent() {
		xMovementP1 = Mathf.Clamp (Input.GetAxis ("Horizontal1"),-1,1);
		xMovementP2 = Mathf.Clamp (Input.GetAxis ("Horizontal2"),-1,1);
	}

	public static void setJump () {
		if (Input.GetButton ("Jump1")) {
			jumpP1 = true;
		} else {
			jumpP1 = false;
		}

		if (Input.GetButton ("Jump2")) {
			jumpP2 = true;
		} else {
			jumpP2 = false;
		}
	}

	public static void setShoot() {
		if (Input.GetButton ("Shoot1")) {
			shootingP1 = true;
		} else {
			shootingP1 = false;
		}
		
		if (Input.GetButton ("Shoot2")) {
			shootingP2 = true;
		} else {
			shootingP2 = false;
		}
	}

	public static float GetRX(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return xAimP1;
			break;
		case Personaje.Pjs.PJ2:
			return xAimP2;
			break;
		default:
			return 0;
			break;
		}
	}

	public static float GetRY(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return yAimP1;
			break;
		case Personaje.Pjs.PJ2:
			return yAimP2;
			break;
		default:
			return 0;
			break;
		}
	}

	public static void setRX(){
		float ejeX1;
		float ejeX2;
		ejeX1 = Input.GetAxis ("RHorizontal1");
		xAimP1 = Mathf.Clamp (ejeX1,-1,1);
		ejeX2 = Input.GetAxis ("RHorizontal2");
		xAimP2 = Mathf.Clamp (ejeX2,-1,1);
	}

	public static void setRY(){
		float ejeY1;
		float ejeY2;
		ejeY1 = Input.GetAxis ("RVertical1");
		yAimP1 = Mathf.Clamp (ejeY1,-1,1);
		ejeY2 = Input.GetAxis ("RVertical2");
		yAimP2 = Mathf.Clamp (ejeY2,-1,1);
	}
}
