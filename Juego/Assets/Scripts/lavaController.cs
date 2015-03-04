using UnityEngine;
using System.Collections;

public class lavaController : MonoBehaviour {
	int lavaTime = 2;
	float lavaTimer = 0;
	public AnimationCurve upDownCurve;
	float timer;
	float startingY;

	// Use this for initialization
	void Start () {
		lavaTimer = 0;
		startingY = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		MovementBounce ();
		lavaTimer += Time.deltaTime;
		if (lavaTimer > lavaTime) {
			transform.position += transform.up * 1.15f * Time.deltaTime;
			startingY += 0.55f * Time.deltaTime;
		}

	}	

	void FixedUpdate(){
		if (timer > 1) {
			timer = 0;
		} else {
			timer += Time.deltaTime;
		}
	}

	void MovementBounce(){
		transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
	}

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player1") {
			Debug.Log("MAMASITA");
		}
	}*/
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Personaje> () != null) {
			//coll.gameObject.GetComponent<Personaje> ().vida -= damage;
			//TimeController.HitStop ();
			Destroy (this.gameObject);
		}  
	}
}
