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
	
	void SetUpWeapon(Personaje c){
		/*trigger.enabled = false;
		if(c.weapon != null)
			Destroy(c.weapon.gameObject);
		c.weapon = this;
		character = c;
		this.transform.parent = character.hand;
		this.transform.localPosition = new Vector3 (0, 0, 0);
		this.transform.localEulerAngles = new Vector3 (0, 0, 0);
		movement = false;*/
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
