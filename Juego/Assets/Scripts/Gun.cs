using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float startingY;
	public float rotationSpeed = 50;
	public GameObject bala;
	public AnimationCurve recoil ;
	public float recoilMagnitude;
	public bool movement = true;
	public Collider2D trigger;
	public Personaje character;

	float timer;
	public float timeBetweenBullet = 10;
	public float dispersion = 0;

	public int ammo;

	public int gun = 1;

	public AnimationCurve upDownCurve;

	public virtual void CheckShooting () {
		if (GameInput.GetPlayerShooting (character.charact) /*&& gun == 1*/) {
				if (timer >= timeBetweenBullet) {
						GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
						baladisparada.transform.RotateAround (baladisparada.transform.position, Vector3.forward, Random.Range (-dispersion, dispersion));
						baladisparada.SetActive (true);
						if (character.charact == Personaje.Pjs.PJ1) {
								baladisparada.layer = LayerMask.NameToLayer ("ShotsPlayer1");
						} else {
								baladisparada.layer = LayerMask.NameToLayer ("ShotsPlayer2");
						}
						character.SetRecoil (recoil, recoilMagnitude);
						timer = 0;
						CheckAmmo ();
				}
		} /*else {
			if (timer>=timeBetweenBullet) {
				for(int i=0;i<6;i++) {
					GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
					baladisparada.transform.RotateAround(baladisparada.transform.position,Vector3.forward,Random.Range(-dispersion,dispersion));
					baladisparada.SetActive (true);

					if(character.charact == Personaje.Pjs.PJ1){
					baladisparada.layer = LayerMask.NameToLayer("ShotsPlayer1");
					
					}else{
						baladisparada.layer = LayerMask.NameToLayer("ShotsPlayer2");
					}
					character.SetRecoil(recoil, recoilMagnitude);
					timer = 0;
					CheckAmmo();
				}
				

			}
		}*/
	}

	void Start () {
		startingY = transform.localPosition.y;
	}

	void OnTriggerEnter2D(Collider2D col){
		Personaje c = col.gameObject.GetComponent<Personaje> ();
		if(c != null)
			SetUpWeapon (c);
	}

	void SetUpWeapon(Personaje c){
		trigger.enabled = false;
		if(c.weapon != null)
			Destroy(c.weapon.gameObject);
		c.weapon = this;
		character = c;
		this.transform.parent = character.hand;
		this.transform.localPosition = new Vector3 (0, 0, 0);
		this.transform.localEulerAngles = new Vector3 (0, 0, 0);
		movement = false;
	}

	void MovementPickUp() {
		if (movement) {
			transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y + Time.deltaTime*rotationSpeed, transform.localEulerAngles.z);
		}
	}

	void FixedUpdate() {
		if (timer > 1) {
			timer = 0;
		} else {
			timer += Time.deltaTime;
		}
		MovementPickUp ();
	}

	protected virtual void CheckAmmo() {
		ammo--;
		if (ammo <= 0) {
			Disable();
		}
	}

	public void Disable() {
		character.weapon = null;
		Destroy (this.gameObject);
	}
}
