using UnityEngine;
using System.Collections;

public class triggerFlamethrower : MonoBehaviour {
	public flamethrower ft;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay2D(Collider2D col){
		if (timer > timeToDamage) {
			if (col.gameObject.GetComponent<Personaje> () != null) {
				//coll.gameObject.GetComponent<Personaje> ().vida -= damage;
				ft.doDamage (col.gameObject.GetComponent<Personaje> ());
				timer = 0;
			} 
		}
	}

	float timer = 0;
	public float timeToDamage = 0.1f;

	void FixedUpdate() {
		timer += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
