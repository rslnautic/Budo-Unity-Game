using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
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
