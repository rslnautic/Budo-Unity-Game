using UnityEngine;
using System.Collections;


public class Fade : MonoBehaviour {
	
	public static int rondasGanadasP1 = 0;
	public static int rondasGanadasP2 = 0;

	public UnityEngine.UI.Image image;

	public UnityEngine.UI.Image ronda1P1;
	public UnityEngine.UI.Image ronda2P1;
	public UnityEngine.UI.Image ronda1P2;
	public UnityEngine.UI.Image ronda2P2;

	public Sprite goldcircle;
	public Sprite greycircle;


	float timer = 2;
	float beginFading = 2.8f;
	float begin = 0;
	float p = 2;
	float a = 4;
	float one = 1;
	// Use this for initialization
	void Start () {
		//var other : GameObject;
		image.color =  new Color(1,1,1,1);
		if(rondasGanadasP1 == 1) ronda1P1.sprite = goldcircle;
		if(rondasGanadasP2 == 1) ronda1P2.sprite = goldcircle;
	}
	
	// Update is called once per frame
	void Update () {
		//(T-P) / (A-P)
		if (one > 0) {
			one -= Time.deltaTime * 0.5f;
			image.color =  new Color(1,1,1,one);
		}
		if (Personaje.winnp1 || Personaje.winnp2) {

			if(Personaje.winnp1){
				if(rondasGanadasP1 == 0) ronda1P1.sprite = goldcircle;
				else if(rondasGanadasP1 == 1) ronda2P1.sprite = goldcircle;
			}
			else if(Personaje.winnp2){
				if(rondasGanadasP2 == 0) ronda1P2.sprite = goldcircle;
				else if(rondasGanadasP2 == 1) ronda2P2.sprite = goldcircle;
			}


			begin += Time.deltaTime;
			if(begin > beginFading){
				timer += Time.deltaTime;
				image.color =  new Color(1,1,1,(timer-p) / (a-p));
			}


			if(begin > 7){
				if(Personaje.winnp1) rondasGanadasP1++;
				else if(Personaje.winnp2) rondasGanadasP2++;
				if (rondasGanadasP1 >= 2) {
					//gana P1
				}
				else if(rondasGanadasP2 >= 2) {
					//gana P2
				}
				else {
					Application.LoadLevel (0); 
				}
			}
		}
	}
}
