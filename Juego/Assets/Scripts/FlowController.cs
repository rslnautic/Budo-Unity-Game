using UnityEngine;
using System.Collections;

public class FlowController : MonoBehaviour {

	public static bool invulnerableP1, invulnerableP2;

	public static void playerDied(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			invulnerableP1 = false;
			invulnerableP2 = true;
			EndUI._instance.PrintWinner(Personaje.Pjs.PJ2);
			Personaje.winnp2 = true;
		} else {
			invulnerableP1 = true;
			invulnerableP2 = false;
			EndUI._instance.PrintWinner(Personaje.Pjs.PJ1);
			Personaje.winnp1 = true;
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		invulnerableP1 = false;
		invulnerableP2 = false;
		Personaje.winnp1 = false;
		Personaje.winnp2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
