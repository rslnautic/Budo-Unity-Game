using UnityEngine;
using System.Collections;

public class FlowController : MonoBehaviour {

	public static bool invulnerableP1, invulnerableP2;

	public static void playerDied(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			invulnerableP1 = false;
			invulnerableP2 = true;
			//PlayerUI.PrintWinner(Personaje.Pjs.PJ2);
		} else {
			invulnerableP1 = true;
			invulnerableP2 = false;
			//PlayerUI.PrintWinner(Personaje.Pjs.PJ1);
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		invulnerableP1 = false;
		invulnerableP2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
