using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	public float maxSpeed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate() {
		rigidbody2D.velocity = GameInput.xMovementP1 * Vector2.right * maxSpeed;
	}
}
