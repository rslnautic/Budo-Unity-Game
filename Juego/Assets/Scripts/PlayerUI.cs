using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public UnityEngine.UI.Text Label;
	public UnityEngine.UI.Text WinnerLabel;
	public Personaje.Pjs character;

	void Update(){
		//Label.text = Time.realtimeSinceStartup + "";
		if (Personaje.GetVida (character) > 0) {
			Label.text = Personaje.GetVida (character) + "";
		}
	}

	/*public static void PrintWinner(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			WinnerLabel.text = "The winner is Player 1";
		} else {
			WinnerLabel.text = "The winner is Player 2";
		}
	}*/
}
