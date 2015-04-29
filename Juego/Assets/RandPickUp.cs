using UnityEngine;
using System.Collections;

public class RandPickUp : MonoBehaviour {
	public GameObject[] possibleSpawns;
	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, possibleSpawns.Length);
		if (rand == possibleSpawns.Length)
			rand = possibleSpawns.Length - 1;

		GameObject g = (GameObject)GameObject.Instantiate (possibleSpawns[rand], transform.position,transform.rotation);
		g.transform.parent = null;
		Destroy (this.gameObject);
	}
}
