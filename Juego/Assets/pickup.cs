using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
	float timer;
	public bool movement = true;
	public float rotationSpeed = 50;
	public float startingY;
	public AnimationCurve upDownCurve;
	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
	}
	void MovementPickUp() {
		if (movement) {
			transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y + Time.deltaTime*rotationSpeed, transform.localEulerAngles.z);
		}
	}

	public Collider2D trigger;
	public Personaje character;

	void OnTriggerEnter2D(Collider2D col){
		Personaje c = col.gameObject.GetComponent<Personaje> ();
		if(c != null)
			SetUpWeapon (c);
	}

	public GameObject[] possibleSpawns;
	
	void SetUpWeapon(Personaje c){
		int rand = Random.Range (0, possibleSpawns.Length);
		if (rand == possibleSpawns.Length)
			rand = possibleSpawns.Length - 1;
		
		GameObject g = (GameObject)GameObject.Instantiate (possibleSpawns[rand], transform.position,transform.rotation);
		g.transform.parent = null;

		Gun gun = g.GetComponent<Gun> ();
		gun.trigger.enabled = false;
		if(c.weapon != null)
			Destroy(c.weapon.gameObject);
		c.weapon = gun;
		gun.character = c;
		gun.transform.parent = c.hand;
		gun.transform.localPosition = new Vector3 (0, 0, 0);
		gun.transform.localEulerAngles = new Vector3 (0, 0, 0);
		gun.movement = false;

		Destroy (this.gameObject);
	}

	void FixedUpdate() {
		if (timer > 1) {
			timer = 0;
		} else {
			timer += Time.deltaTime;
		}
		MovementPickUp ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
