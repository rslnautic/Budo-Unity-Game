using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
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
}