using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public int damage;
	public float speed = 2;

	void Update () {
		MoveBullet (speed);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Personaje> () != null) {
				coll.gameObject.GetComponent<Personaje> ().vida -= damage;
				TimeController.HitStop ();
				Destroy (this.gameObject);
		} 

		if (coll.gameObject.tag == "Platforms") {
			Destroy (this.gameObject);
		}
	}

	public void MoveBullet(float velocidad){
		transform.position += transform.right * velocidad * Time.deltaTime;
		if (transform.position.x > 300) {
			Destroy (this.gameObject);		
		}
	}
}