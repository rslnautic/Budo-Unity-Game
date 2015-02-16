using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {


	public static float damage;

	public GameObject bala;
	public AnimationCurve recoil ;
	public float recoilMagnitude;

	public Collider2D trigger;

	public Personaje character;
	
	public void CheckShooting () {
		if (GameInput.GetPlayerShooting(character.charact)) {
			GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
			baladisparada.SetActive (true);
			character.SetRecoil(recoil, recoilMagnitude);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		Personaje c = col.gameObject.GetComponent<Personaje> ();
		if(c != null)
			SetUpWeapon (c);
	}

	void SetUpWeapon(Personaje c){
		trigger.enabled = false;
		Destroy(c.weapon.gameObject);
		c.weapon = this;
		character = c;
		this.transform.parent = character.hand;
		this.transform.localPosition = new Vector3 (0, 0, 0);
		this.transform.localEulerAngles = new Vector3 (0, 0, 0);
	}
}
