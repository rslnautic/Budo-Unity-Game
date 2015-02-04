using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	public float maxSpeed = 5;

	public AnimationCurve XCurve;
	public float aceleracion = 5;
	public float aceleracionInversa= 7;
	public float frenado = 12;

	float xlateralcurveposition = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}
	enum MoveState {HELD,JUMPING,FALLING}
	
	MoveState moveState = MoveState.HELD;
	
	
	public AnimationCurve jumpSpeedCurve;
	public float jumpTime = 0.5f;
	float jumpTimer = 0;
	public float jumpSpeed = 30;
	
	public AnimationCurve fallSpeedCurve;
	float fallTimer = 0;
	public float maxFallSpeed = 50;
	public float fallSpeed = 60;


	void FixedUpdate() {
		float direction = 0;
		bool frenando = false;
		if (GameInput.xMovementP1 > 0.1f || GameInput.xMovementP1 < -0.1f) {
			direction = GameInput.xMovementP1;
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
		Mathf.Clamp (xlateralcurveposition,-1,1);   // Limita los valores minimos y maximos de una curva
		
		xlateralcurveposition += direction * Time.deltaTime;

		if (frenando) {
			if(xlateralcurveposition > 0.5f && direction >0 || xlateralcurveposition < 0.5f && direction <0)
			{
				xlateralcurveposition = 0.5f;
			}
		}

		float lateralspeed = XCurve.Evaluate (xlateralcurveposition);
		rigidbody2D.velocity = Vector2.right * maxSpeed * lateralspeed;

		/////////////////////////////////////////////////////////////////////
		if(GameInput.jumpP1 && moveState == MoveState.HELD){
			jumpTimer = 0;
			moveState = MoveState.JUMPING;
		}
		
		
		switch (moveState) {
		case MoveState.JUMPING:
			jumpTimer += Time.deltaTime;
			float normalizedJumpTime = jumpTimer / jumpTime;
			float jumpSpeedInTime = jumpSpeedCurve.Evaluate (normalizedJumpTime) * jumpSpeed;
			float xSpeed = GameInput.xMovementP1 * maxSpeed;
			Vector2 vel = Vector2.right * xSpeed + Vector2.up * jumpSpeedInTime;
			rigidbody2D.velocity = vel;
			if (normalizedJumpTime >= 1) {
				moveState = MoveState.FALLING;
				fallTimer = 0;
			}
			if(normalizedJumpTime > 0.3 && !Input.GetKey(KeyCode.W)){
				moveState = MoveState.FALLING;
				fallTimer = 0;
			}
			break;
		case MoveState.FALLING:
			if(fallTimer < 1.2)
				fallTimer += Time.deltaTime;
			//float normalizedFallTime = fallTimer / maxFallSpeed;
			float fallSpeedInTime = fallSpeedCurve.Evaluate (fallTimer) * fallSpeed;
			float xSpeed2 = GameInput.xMovementP1 * maxSpeed;
			Vector2 vel2 = Vector2.right * xSpeed2 - Vector2.up * fallSpeedInTime;
			rigidbody2D.velocity = vel2;
			break;
		}
	}
}
