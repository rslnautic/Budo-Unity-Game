using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public UnityEngine.UI.Image image;
	float timer = 2;
	float beginFading = 3;
	float begin = 0;
	float p = 2;
	float a = 4;
	float one = 1;
	// Use this for initialization
	void Start () {
		//var other : GameObject;
		image.color =  new Color(1,1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
		//(T-P) / (A-P)
		if (one > 0) {
			one -= Time.deltaTime;
			image.color =  new Color(1,1,1,one);
		}
		if (Personaje.winnp1 || Personaje.winnp2) {
			begin += Time.deltaTime * 0.8f;
			if(begin > beginFading){
				timer += Time.deltaTime;
				image.color =  new Color(1,1,1,(timer-p) / (a-p));
			}
			if(begin > 4.8){
				Application.LoadLevel (0);  
			}

		}
	}
}
