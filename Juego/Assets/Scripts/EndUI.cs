using UnityEngine;
using System.Collections;

public class EndUI : MonoBehaviour {

	public static EndUI _instance;
	public UnityEngine.UI.Text WinnerLabel;
	
	void Start(){
		_instance = this;
	}
	
	public  void PrintWinner(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			WinnerLabel.text = "The winner is Player 1";
		} else {
			WinnerLabel.text = "The winner is Player 2";
		}
	}
}
