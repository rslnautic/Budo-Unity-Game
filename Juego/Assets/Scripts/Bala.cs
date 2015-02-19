using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	public int damage;
	
	public float velocidad = 5;
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.right * velocidad * Time.deltaTime;
		if (transform.position.x > 300) {
			Destroy (this.gameObject);		
		}
	}
	
	/*void OnCollisionEnter(Collision coll){
		if (coll.gameObject.GetComponent<Enemy> () != null) {
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}*/

	//coll.gameObject.GetComponent<Personaje> ().Die();

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Personaje> () != null) {
			coll.gameObject.GetComponent<Personaje> ().vida -= damage;
			TimeController.HitStop();
			Destroy (this.gameObject);
		}
	}
}