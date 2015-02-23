using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public float rotationSpeed = 60;

	// Use this for initialization
	void Start () {
	
	}

	//  GUN OBJECT AROUND THE Z-AXIS
	// BASED ON THE ANGLE OF THE RIGHT ANALOG STICK
	float x = Input.GetAxis ("RHorizontalJoySti1");
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
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + aim_angle * rotationSpeed);
		}
	}

	void MovementPickUp() {
		//if (movement) {
			//transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + aim_angle * rotationSpeed);
		//}
	}
	
}
