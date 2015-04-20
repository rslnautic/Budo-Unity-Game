using UnityEngine;
using System.Collections;

public class Shootgun : Gun {

	

	// Use this for initialization
	void Start () {
	
	}

	float timer;
	public float timeBetweenBullet = 10;
	public float dispersion = 0;


	public override void CheckShooting () {
		if (GameInput.GetPlayerShooting(character.charact)) {
			if (timer>=timeBetweenBullet) {
				GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
				baladisparada.transform.RotateAround(baladisparada.transform.position,Vector3.forward,Random.Range(-dispersion,dispersion));
				baladisparada.SetActive (true);

				GameObject baladisparada2 = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
				baladisparada2.transform.RotateAround(baladisparada2.transform.position,Vector3.forward,Random.Range(-dispersion,dispersion));
				baladisparada2.SetActive (true);

				GameObject baladisparada3 = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
				baladisparada3.transform.RotateAround(baladisparada3.transform.position,Vector3.forward,Random.Range(-dispersion,dispersion));
				baladisparada3.SetActive (true);

				GameObject baladisparada4 = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
				baladisparada4.transform.RotateAround(baladisparada4.transform.position,Vector3.forward,Random.Range(-dispersion,dispersion));
				baladisparada4.SetActive (true);

				if(character.charact == Personaje.Pjs.PJ1){
					baladisparada.layer = LayerMask.NameToLayer("ShotsPlayer1");
					baladisparada2.layer = LayerMask.NameToLayer("ShotsPlayer1");
					baladisparada3.layer = LayerMask.NameToLayer("ShotsPlayer1");
					baladisparada4.layer = LayerMask.NameToLayer("ShotsPlayer1");

				}else{
					baladisparada.layer = LayerMask.NameToLayer("ShotsPlayer2");
					baladisparada2.layer = LayerMask.NameToLayer("ShotsPlayer2");
					baladisparada3.layer = LayerMask.NameToLayer("ShotsPlayer2");
					baladisparada4.layer = LayerMask.NameToLayer("ShotsPlayer2");
				}
				character.SetRecoil(recoil, recoilMagnitude);
				timer = 0;
				CheckAmmo();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
