using UnityEngine;
using System.Collections;

public class Shootgun : Gun {



	public override void CheckShooting () {
		if (GameInput.GetPlayerShooting(character.charact)) {
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
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
