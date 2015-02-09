using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	public float maxSpeed = 5;

	public AnimationCurve XCurve;
	public float aceleracion = 5;
	public float aceleracionInversa= 7;
	public float frenado = 12;

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
	void Update () {


	}
	enum MoveState {HELD,JUMPING,FALLING}
	
	MoveState moveState = MoveState.FALLING;	
	
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

	float fallHoldTimer = 0;
	float fallHoldTime =0.15f;

	void FixedUpdate() {
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

		if(GameInput.jumpP1 && moveState == MoveState.HELD){
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
			if(normalizedJumpTime > 0.3 && !Input.GetKey(KeyCode.W)){
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
			break;
		}
		
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
		xlateralcurveposition += direction * Time.deltaTime * factor;
		if (frenando) {
			if(xlateralcurveposition > 0.5f && direction >0 || xlateralcurveposition < 0.5f && direction <0)
			{
				xlateralcurveposition = 0.5f;
			}
		}	
		float lateralspeed = XCurve.Evaluate (xlateralcurveposition);
		rigidbody2D.velocity = (Vector2.right * maxSpeed * lateralspeed) - verticalMovement;
	}
}
