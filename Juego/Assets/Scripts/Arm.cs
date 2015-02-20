using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public float rotationSpeed = 60;

	// Use this for initialization
	void Start () {
	
	}

	//  GUN OBJECT AROUND THE Z-AXIS
	// BASED ON THE ANGLE OF THE RIGHT ANALOG STICK
	float x = Input.GetAxis ("RHorizontalJoyStick1");
	float y = Input.GetAxis ("RVerticalJoyStick1");
	float aim_angle = 0.0f;
	bool aiming_right = false;
	bool aiming_up = false;




	void Update() {
		// USED TO CHECK OUTPUT
		//Debug.Log(" horz: " + x + "   vert: " + y);
		
		// CANCEL ALL INPUT BELOW THIS FLOAT
		float R_analog_threshold = 0.20f;
	
		if (Mathf.Abs(x) < R_analog_threshold) {x = 0.0f;} 
		
		if (Mathf.Abs(y) < R_analog_threshold) {y = 0.0f;} 
		
		// CALCULATE ANGLE AND ROTATE
		if (x != 0.0f || y != 0.0f) {
			
			aim_angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			
			// ANGLE GUN
			//gun_test.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + aim_angle * rotationSpeed);
		}
	}

	void MovementPickUp() {
		//if (movement) {
			//transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + aim_angle * rotationSpeed);
		//}
	}

	//NADA
	/*
	public float maxSpeed = 0.5f;
	
	// Update is called once per frame
	void Update () {
		/*Vector2 firingDirection = Vector2.right*GameInput.ejeXDisparo + Vector2.up*GameInput.ejeYDisparo;
		if (firingDirection.magnitude > 0.2f) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, firingDirection),rotationInterpolation*Time.deltaTime);
		}*
	}

	void fixUpdate() {
		rigidbody2D.velocity = GameInput.ejeX * Vector2.right + GameInput.ejeY * Vector2.up;
		rigidbody2D.velocity.Normalize();
		rigidbody2D.velocity = rigidbody2D.velocity * maxSpeed;
		
		/*if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
			baladisparada.SetActive (true);
		}

	}*/
}
