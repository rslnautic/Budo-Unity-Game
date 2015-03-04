using UnityEngine;
using System.Collections;

public class CameraDeathTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Personaje> () != null) {
				coll.gameObject.GetComponent<Personaje> ().vida -= 100;
				//TimeController.HitStop ();
				//Destroy (this.gameObject);
		} 
	}
}
