using UnityEngine;
using System.Collections;

public class flamethrower : Gun {

	public ParticleSystem flames;
	public int damage;

	RaycastHit2D resultado;
	// Use this for initialization 
	void Start () {
		startingY = transform.localPosition.y;
	}
	public float fuel = 10;

	bool shooting = false;

	public override void CheckShooting () {
		if (GameInput.GetPlayerShooting (character.charact) && fuel > 0) {
				fuel -= Time.deltaTime;
				shooting = true;
					//resultado = Physics2D.CircleCast(;
					//resultado.collider.gameObject.
				if (!flames.isPlaying) {
					flames.Play();
				}
			} else {
				shooting = false;
				if(flames.isPlaying)
				{
					flames.Stop();
				}
			}
	}

	public void doDamage(Personaje pj) {
		if (shooting) {
			pj.vida -= damage;
		}
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
