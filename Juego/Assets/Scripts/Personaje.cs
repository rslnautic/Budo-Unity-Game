﻿using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	public float maxSpeed = 5;

	public AnimationCurve XCurve;
	public float aceleracion = 5;
	public float aceleracionInversa= 7;
	public float frenado = 12;

	public int vida = 10;

	bool lookingRight = true;

	float xlateralcurveposition = 0.5f;
	//RaycastHit2D hit;
	
	/*void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.GetComponent<Platform> () != null) {
			moveState = MoveState.HELD;
		}
	}*/

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	enum MoveState {HELD,JUMPING,FALLING,WALL}
	public enum Pjs {PJ1,PJ2}
	MoveState moveState = MoveState.FALLING;
	public Pjs charact;
	
	public AnimationCurve jumpSpeedCurve;
	public float jumpTime = 0.5f;
	float jumpTimer = 0;
	public float jumpSpeed = 30;
	
	public AnimationCurve fallSpeedCurve;
	float fallTimer = 0;
	public float maxFallSpeed = 50;
	public float fallSpeed = 60;
	public LayerMask groundLayers;
	public float holdingFactor = 1;
	public float jumpingFactor = 0.8f;
	public float fallingFactor = 0.6f;
	public bool jumpedWall = false;
	public bool wallJumpingRight = true;

	float fallHoldTimer = 0;
	float fallHoldTime =0.15f;

	public Gun weapon;
	
	public Transform hand;
	public Transform visualCharacter;

	void FixedUpdate() {

		setLayer ();
		SetLookingDirection ();
		checkLife ();

		//static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .55f, groundLayers);
		if (hit.collider != null) {
				moveState = MoveState.HELD;
			fallHoldTimer = 0;
		} else {
			if(moveState == MoveState.HELD){
				fallHoldTimer += Time.deltaTime;
				if(fallHoldTimer > fallHoldTime)moveState = MoveState.FALLING;
			}
		}

		if(GameInput.GetPlayerJump(charact) && moveState == MoveState.HELD){
			jumpTimer = 0;
			moveState = MoveState.JUMPING;
		}
		float factor = 0;
		//moveState es el estado en el que esta el jugador, puede estar en el suelo(HELD), saltando(JUMPING),
		//o cayendo(FALLING)
		Vector2 verticalMovement = Vector2.zero;

		switch (moveState) {
		case MoveState.HELD:
			factor = holdingFactor;
			verticalMovement = Vector2.up*.05f;
			break;
		case MoveState.JUMPING:
			
			factor = jumpingFactor;
			jumpTimer += Time.deltaTime;
			float normalizedJumpTime = jumpTimer / jumpTime;
			float jumpSpeedInTime = jumpSpeedCurve.Evaluate (normalizedJumpTime) * jumpSpeed;
			verticalMovement = -Vector2.up * jumpSpeedInTime;
			if (normalizedJumpTime >= 1) {
				moveState = MoveState.FALLING;
				fallTimer = 0;
			}
			if(normalizedJumpTime > 0.3 && !GameInput.GetPlayerJump(charact)){
				moveState = MoveState.FALLING;
				fallTimer = 0;
			}
			break;
		case MoveState.FALLING:
			
			factor = fallingFactor;
			if(fallTimer < 1.2)
				fallTimer += Time.deltaTime;
			//float normalizedFallTime = fallTimer / maxFallSpeed;
			float fallSpeedInTime = fallSpeedCurve.Evaluate (fallTimer) * fallSpeed;
			verticalMovement = Vector2.up * fallSpeedInTime;
			
			RaycastHit2D hitL = Physics2D.Raycast(transform.position, -Vector2.right, .55f, groundLayers);
			RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, .55f, groundLayers);
			if (hitL.collider != null || hitR.collider != null) {
				moveState = MoveState.WALL;
			}
			break;
		case MoveState.WALL:
			factor = fallingFactor;
			if(fallTimer < 1.2)
				fallTimer += Time.deltaTime;

			float fallSpeedInTime2 = fallSpeedCurve.Evaluate (fallTimer) * fallSpeed;
			verticalMovement = Vector2.up* 0.2f * fallSpeedInTime2;
			//visualCharacter.localEulerAngles = new Vector3 (0, -180, 0);

			RaycastHit2D hitL2 = Physics2D.Raycast(transform.position, -Vector2.right, .55f, groundLayers);
			RaycastHit2D hitR2 = Physics2D.Raycast(transform.position, Vector2.right, .55f, groundLayers);
			if (hitL2.collider == null && hitR2.collider == null) {
				moveState = MoveState.FALLING;
			}
			if(hitL2.collider != null){
				visualCharacter.localEulerAngles = new Vector3 (8, 0, 0);
			}
			else if(hitR2.collider != null){
				visualCharacter.localEulerAngles = new Vector3 (0, 180, 0);
			}

			wallJumpingRight = true;

			if(hitR2.collider != null)
				wallJumpingRight = false;

			if(GameInput.GetPlayerJump(charact) && !jumpedWall){
				//jumpedWall = true;
				jumpTimer = 0;
				moveState = MoveState.JUMPING;
				if(wallJumpingRight){
					xlateralcurveposition = 0.9f;
				}else{
					xlateralcurveposition = 0.1f;
				}
			}
			break;
		}
		
		float direction = 0;
		bool frenando = false;
		if (GameInput.GetPlayerXMovement(charact) > 0.1f || GameInput.GetPlayerXMovement(charact) < -0.1f) {
			direction = GameInput.GetPlayerXMovement(charact);
			if(direction>0 && xlateralcurveposition >0.5f || direction < 0 && xlateralcurveposition <0.5f){
				direction*=aceleracion;
			} else {
				direction*=aceleracionInversa;
			}
		} else {
			frenando = true;
			if(xlateralcurveposition > 0.5f)
			{
				direction =-frenado;
			} else {
				direction =frenado;
			}
		}
		// Limita los valores minimos y maximos de una curva	
		xlateralcurveposition += direction * Time.deltaTime * factor;
		

		if (frenando) {
			if(xlateralcurveposition > 0.5f && direction >0 || xlateralcurveposition < 0.5f && direction <0)
			{
				xlateralcurveposition = 0.5f;
			}
		}	
		xlateralcurveposition = Mathf.Clamp (xlateralcurveposition,0,1);
		if(weapon != null)
		weapon.CheckShooting ();

		float lateralspeed = XCurve.Evaluate (xlateralcurveposition);
		rigidbody2D.velocity = (Vector2.right * maxSpeed * lateralspeed) - verticalMovement;
	}

	
	public void SetRecoil(AnimationCurve r, float m){
		float normalized = Mathf.Abs ((xlateralcurveposition - 0.5f) / 0.5f);
		float rec = r.Evaluate (normalized)*m;
		
		if (lookingRight) {
			xlateralcurveposition -= rec;
		} else {
			xlateralcurveposition += rec;
		}
	}

	void SetLookingDirection(){
		if (GameInput.GetPlayerXMovement (charact) > 0.2f) {
			lookingRight = true;		
		} else if (GameInput.GetPlayerXMovement (charact) < -0.2f) {
			lookingRight = false;
		}
		if (lookingRight) {
			visualCharacter.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			visualCharacter.localEulerAngles = new Vector3 (0, 180, 0);
		}
	}

	void checkLife(){
		if (vida <= 0) 
		{
			vida = 0;
			Destroy (this.gameObject);
		}
		switch (charact) {
		case Personaje.Pjs.PJ1:
			vida1 = vida;
			break;
		case Personaje.Pjs.PJ2:
			vida2 = vida;
			break;
		default:
			break;
		}
	}

	static int vida1;
	static int vida2;

	public static int GetVida(Personaje.Pjs p){
		switch (p) {
		case Personaje.Pjs.PJ1:
			return vida1;
			break;
		case Personaje.Pjs.PJ2:
			return vida2;
			break;
		default:
			return 0;
			break;
		}
		
	}

	void setLayer() {
		if(this.charact == Personaje.Pjs.PJ1){
			this.gameObject.layer = LayerMask.NameToLayer("Player1");
		}else{
			this.gameObject.layer = LayerMask.NameToLayer("Player2");
		}

	}
}
