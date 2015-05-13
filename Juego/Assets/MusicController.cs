using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Fade.rondasGanadasP1>0 | Fade.rondasGanadasP2>0) {
			Debug.Log("no es la primera partida");
			Destroy(this.gameObject);

		} else {
			Debug.Log("Primera partida");
			DontDestroyOnLoad(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
