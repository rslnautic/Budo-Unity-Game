using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	//public UnityEngine.UI.Text Label;
	public UnityEngine.UI.Image Barra;
	public Personaje.Pjs character;

	void Update(){
		//Label.text = Time.realtimeSinceStartup + "";
		/*if (Personaje.GetVida (character) > 0) {
			//Label.text = Personaje.GetVida (character) + "";
		}*/
		float porcentajeBarra = ((float)Personaje.GetVida (character)) / ((float)Personaje.GetVidaMaxima (character));
		Barra.fillAmount = porcentajeBarra;

		if(porcentajeBarra < .66f && porcentajeBarra > .33f )Barra.color = new Color (255, 255, 0);
		else if(porcentajeBarra < .33f) Barra.color = new Color (255, 0, 0);

	}

	/*public static void PrintWinner(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			WinnerLabel.text = "The winner is Player 1";
		} else {
			WinnerLabel.text = "The winner is Player 2";
		}
	}*/
}
