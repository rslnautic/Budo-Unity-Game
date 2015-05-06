using UnityEngine;
using System.Collections;

public class EndUI : MonoBehaviour {

	public static EndUI _instance;
	public UnityEngine.UI.Text WinnerLabel;
	public UnityEngine.UI.Image WinnerImage;

	public Sprite P1WinsRound;
	public Sprite P1Wins;
	public Sprite P2WinsRound;
	public Sprite P2Wins;
	public Sprite NullSprite;
	
	void Start(){
		_instance = this;
		WinnerImage.sprite = NullSprite;

	}
	
	public  void PrintWinner(Personaje.Pjs c) {
		if (c == Personaje.Pjs.PJ1) {
			if(Fade.rondasGanadasP1 == 0) WinnerImage.sprite = P1WinsRound;
			else if(Fade.rondasGanadasP1 >= 1) WinnerImage.sprite = P1Wins;
			//WinnerLabel.text = "The winner is Player 1";
		} else {
			if(Fade.rondasGanadasP2 == 0) WinnerImage.sprite = P2WinsRound;
			else if(Fade.rondasGanadasP2 >= 1) WinnerImage.sprite = P2Wins;
			//WinnerLabel.text = "The winner is Player 2";
		}
	}
}
