using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public UnityEngine.UI.Text Label;
	public Personaje.Pjs character;

	void Update(){
		//Label.text = Time.realtimeSinceStartup + "";
		if (Personaje.GetVida (character) > 0) {
			Label.text = Personaje.GetVida (character) + "";
		}
	}
}
