using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	
	private Vector3 offset;
	private Vector3 newOffset;

	public float interpolationSt = 3;
	public float verticalOffset = 5;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float media;
		if (!p1.GetComponent<Personaje> ().dying && !p2.GetComponent<Personaje> ().dying) {
				media = (p1.transform.position.y + p2.transform.position.y) / 2;
				newOffset = Vector3.Lerp (transform.position, new Vector3 (offset.x, media + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
		} else {
			if(!p1.GetComponent<Personaje>().dying) {
				newOffset = Vector3.Lerp (transform.position, new Vector3 (offset.x, p1.transform.position.y + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
			} else if(!p2.GetComponent<Personaje>().dying) {
				newOffset = Vector3.Lerp (transform.position, new Vector3 (offset.x, p2.transform.position.y + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
			}
		}

	}
}
