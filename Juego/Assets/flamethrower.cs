using UnityEngine;
using System.Collections;

public class flamethrower : Gun {

	public ParticleSystem flames;

	RaycastHit2D resultado;
	// Use this for initialization 
	void Start () {
		startingY = transform.localPosition.y;
	}
	public float fuel = 10;

	public override void CheckShooting () {
		if (GameInput.GetPlayerShooting (character.charact) && fuel > 0) {
				fuel -= Time.deltaTime;
					//resultado = Physics2D.CircleCast(;
					//resultado.collider.gameObject.
				if (!flames.isPlaying) {
					flames.Play();
				}
			} else {
				if(flames.isPlaying)
				{
					flames.Stop();
				}
			}
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
