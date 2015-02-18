using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bala;
	public AnimationCurve recoil ;
	public float recoilMagnitude;

	public Collider2D trigger;

	public Personaje character;

	float timer;
	public float timeBetweenBullet = 10;
	public float dispersion = 0;

	public virtual void CheckShooting () {
		if (GameInput.GetPlayerShooting(character.charact)) {
			if (timer>=timeBetweenBullet) {
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
			}
		}
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
	}

	void FixedUpdate() {
		timer += Time.deltaTime;

	}


}
