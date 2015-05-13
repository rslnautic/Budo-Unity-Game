using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	
	private Vector3 offset;
	private Vector3 newOffset;

	public float externalZone = 0.3f;
	public float internalZone = 0.5f;
	public float cameraInterpolationSpeed = 1;
	public float nimfov = 6;
	public float maxfov = 12;

	public float interpolationSt = 3;
	public float verticalOffset = 5;

	public GameObject p1Verde;
	public GameObject p1Azul;
	public GameObject p1Rojo;
	
	public GameObject p2Verde;
	public GameObject p2Azul;
	public GameObject p2Rojo;

	public UnityEngine.UI.Image image;
	// Use this for initialization
	void Start () {
		offset = transform.position;
		image.CrossFadeAlpha(0,0,true);	

		switch (MenuController.positionSelectP1) 
		{
		case 1:
			p1 = p1Verde;
			p1Verde.SetActive(true);
			break;
		case 2:
			p1 = p1Azul;
			p1Azul.SetActive(true);
			break;
		case 3:
			p1 = p1Rojo;
			p1Rojo.SetActive(true);
			break;
		default:
			break;
		}

		switch (MenuController.positionSelectP2) 
		{
		case 1:
			p2 = p2Verde;
			p2Verde.SetActive(true);
			break;
		case 2:
			p2 = p2Azul;
			p2Azul.SetActive(true);
			break;
		case 3:
			p2 = p2Rojo;
			p2Rojo.SetActive(true);
			break;
		default:
			break;
		}
	}

	public AnimationCurve WarningAlphaCurve;
	public float warningBlink;
	float warningTimer;
	public float deathPv;
	public float deathPvSpeed;
	public float deathTime;
	float deathTimer = 0;
	
	// Update is called once per frame
	void Update () {
		float mediay, mediax;
		mediax = (p1.transform.position.x + p2.transform.position.x) / 2;

		if (!p1.GetComponent<Personaje> ().dying && !p2.GetComponent<Personaje> ().dying) {
				mediay = (p1.transform.position.y + p2.transform.position.y) / 2;
			newOffset = Vector3.Lerp (transform.position, new Vector3 (mediax, mediay + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
		} else {
			if(!p1.GetComponent<Personaje>().dying) {
				newOffset = Vector3.Lerp (transform.position, new Vector3 (p1.transform.position.x, p1.transform.position.y + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
			} else if(!p2.GetComponent<Personaje>().dying) {
				newOffset = Vector3.Lerp (transform.position, new Vector3 (p2.transform.position.x, p2.transform.position.y + verticalOffset, offset.z), Time.deltaTime * interpolationSt);
				transform.position = newOffset;
			}

			deathTimer += Time.deltaTime;
			float fov = Mathf.Lerp(Camera.main.fieldOfView, deathPv, deathPvSpeed * Time.deltaTime);
			Camera.main.fieldOfView = fov;
		}

		UpdateCameraShow ();
		DoWarning ();
	}

	void UpdateCameraShow() {
		Vector3 screenPosP1 = camera.WorldToScreenPoint(p1.transform.position);
		Vector3 screenPosP2 = camera.WorldToScreenPoint(p2.transform.position);

		screenPosP1 = new Vector3 (screenPosP1.x / Camera.main.pixelWidth, screenPosP1.y / Camera.main.pixelHeight, 0);
		screenPosP2 = new Vector3 (screenPosP2.x / Camera.main.pixelWidth, screenPosP2.y / Camera.main.pixelHeight, 0);

		bool internalShow = true;
		bool externalShow = false;

		float amm = 1;

		if (screenPosP1.x < internalZone || screenPosP1.y < internalZone || screenPosP1.x > 1 - internalZone || screenPosP1.y > 1 - internalZone 
						|| screenPosP2.x < internalZone || screenPosP2.y < internalZone || screenPosP2.x > 1 - internalZone || screenPosP2.y > 1 - internalZone) {
						internalShow = false;
				} else {
			float dist = Mathf.Max (new float[] {screenPosP1.x,screenPosP1.y,screenPosP2.x,screenPosP2.y, 1 -screenPosP1.x ,1 -screenPosP1.y,1 -screenPosP2.x ,1 -screenPosP2.y });
				if(dist > 0.5f)
					dist = 1 - dist;
				dist -= internalZone; 
				amm	= 0.5f - internalZone;
				amm = dist/amm;
			}
		if(!internalShow) {
			if (screenPosP1.x < externalZone || screenPosP1.y < externalZone || screenPosP1.x > 1 - externalZone || screenPosP1.y > 1 - externalZone 
			    || screenPosP2.x < externalZone || screenPosP2.y < externalZone || screenPosP2.x > 1 - externalZone || screenPosP2.y > 1 - externalZone) {
				externalShow = true;
				float dist = Mathf.Max (new float[] {externalZone - screenPosP1.x,externalZone - screenPosP1.y,externalZone - screenPosP2.x,externalZone - screenPosP2.y, 
					screenPosP1.x - (1 - externalZone) ,screenPosP1.y - (1 - externalZone),screenPosP2.x - (1 - externalZone),screenPosP2.y - (1 - externalZone)});
				amm	= externalZone;
				amm = dist/amm;
				//Debug.Log (amm);
			}
		}

		if (deathTimer == 0) {
			
			float fov = Camera.main.fieldOfView;
			if (internalShow) {
				fov = Mathf.Lerp(fov,nimfov, amm*cameraInterpolationSpeed * Time.deltaTime);
			} else if(externalShow) {
				fov = Mathf.Lerp(fov,maxfov, amm*cameraInterpolationSpeed * Time.deltaTime);
			}
			Camera.main.fieldOfView = fov;

		}




	}

	public float warningHeight = 0.2f;

	void DoWarning(){

		warningTimer += Time.deltaTime;
		float bt = WarningAlphaCurve.Evaluate (warningTimer / warningBlink);
		Vector3 screenPosP1 = camera.WorldToScreenPoint(p1.transform.position);
		Vector3 screenPosP2 = camera.WorldToScreenPoint(p2.transform.position);
		if ((screenPosP1.y / Camera.main.pixelHeight < warningHeight || screenPosP2.y / Camera.main.pixelHeight < warningHeight) && deathTimer == 0) {
						image.CrossFadeAlpha (0.5f, 1,true);		
				} else {
			image.CrossFadeAlpha(0,1,true);		
		} 
		image.color = new Color (1, 1, 1, bt);
	}
}

















