using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public UnityEngine.UI.Text Label;
	public Personaje.Pjs character;

	void Update(){
		//Label.text = Time.realtimeSinceStartup + "";
		Label.text = Personaje.GetVida (character) + "";

	}
}
