using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public UnityEngine.UI.Image selectP1;
	public UnityEngine.UI.Image selectP2;
	public UnityEngine.UI.Image readyP1;
	public UnityEngine.UI.Image readyP2;
	
	public Sprite selectYellow;
	public Sprite selectBlack;

	public Transform player1Selector;
	public Transform player1SelectorPos1;
	public Transform player1SelectorPos2;
	public Transform player1SelectorPos3;
	public Transform player2Selector;
	public Transform player2SelectorPos1;
	public Transform player2SelectorPos2;
	public Transform player2SelectorPos3;

	public static int positionSelectP1;
	public static int positionSelectP2;

	float delay = .50f;
	float timerj1 = 0;
	float timerj2 = 0;
	float timerBothSelected = 0;
	bool selectedP1;
	bool selectedP2;


	// Use this for initialization
	void Start () {
		positionSelectP1 = 1;
		positionSelectP2 = 1;
		selectedP1 = false;
		selectedP2 = false;
		readyP1.CrossFadeAlpha (0, 0, true);
		readyP2.CrossFadeAlpha (0, 0, true);
		selectP1.sprite = selectBlack;
		selectP2.sprite = selectBlack;
	}
	
	// Update is called once per frame
	void Update () {

		if (selectedP1 && selectedP2) 
		{
			timerBothSelected += Time.deltaTime;
			if(timerBothSelected >= delay)
			{
				Application.LoadLevel (1);
			}
		}

		if (GameInput.GetPlayerJump (Personaje.Pjs.PJ1)) {
			if(timerj1 >= 0.25f)
			{
				timerBothSelected = 0;
				if(selectedP1)
				{
					selectedP1 = false;
					selectP1.sprite = selectBlack;
					readyP1.CrossFadeAlpha (0, .10f, true);
				}
				else
				{
					selectedP1 = true;
					selectP1.sprite = selectYellow;
					readyP1.CrossFadeAlpha (1, .10f, true);
				}
				timerj1 = 0;
			}
		}

		if (GameInput.GetPlayerJump (Personaje.Pjs.PJ2)) {
			if(timerj2 >= 0.25f)
			{
				timerBothSelected = 0;
				if(selectedP2)
				{
					selectedP2 = false;
					selectP2.sprite = selectBlack;
					readyP2.CrossFadeAlpha (0, .10f, true);
				}
				else
				{
					selectedP2 = true;
					selectP2.sprite = selectYellow;
					readyP2.CrossFadeAlpha (1, .10f, true);
				}
				timerj2 = 0;
			}
		}


		if (timerj1 <= 0.25f)
						timerj1 += Time.deltaTime;

		if(timerj1 >= 0.25f && !selectedP1)
		{
			if (GameInput.GetRY (Personaje.Pjs.PJ1) >= 0.5f) {
				positionSelectP1--;
				if(positionSelectP1 < 1){
					positionSelectP1 = 3;
				}
				timerj1 = 0;
			}
			if (GameInput.GetRY (Personaje.Pjs.PJ1) <= -0.5f) {
				positionSelectP1++;
				if(positionSelectP1 > 3){
					positionSelectP1 = 1;
				}
				timerj1 = 0;
			}
		}

		switch (positionSelectP1) {
		case 1:
			player1Selector.position = Vector3.Lerp (player1Selector.position, new Vector3(player1SelectorPos1.position.x,player1SelectorPos1.position.y,player1Selector.position.z),Time.deltaTime*10);
			break;
		case 2:
			player1Selector.position = Vector3.Lerp (player1Selector.position, new Vector3(player1SelectorPos1.position.x,player1SelectorPos2.position.y,player1Selector.position.z),Time.deltaTime*10);
			break;
		case 3:
			player1Selector.position = Vector3.Lerp (player1Selector.position, new Vector3(player1SelectorPos1.position.x,player1SelectorPos3.position.y,player1Selector.position.z),Time.deltaTime*10);
			break;
		default:
			break;
		}

		if (timerj2 <= 0.25f)
			timerj2 += Time.deltaTime;
		
		if(timerj2 >= 0.25f && !selectedP2)
		{
			if (GameInput.GetRY (Personaje.Pjs.PJ2) >= 0.5f) {
				positionSelectP2--;
				if(positionSelectP2 < 1){
					positionSelectP2 = 3;
				}
				timerj2 = 0;
			}
			if (GameInput.GetRY (Personaje.Pjs.PJ2) <= -0.5f) {
				positionSelectP2++;
				if(positionSelectP2 > 3){
					positionSelectP2 = 1;
				}
				timerj2 = 0;
			}
		}

		switch (positionSelectP2) {
		case 1:
			player2Selector.position = Vector3.Lerp (player2Selector.position, new Vector3(player2SelectorPos1.position.x,player1SelectorPos1.position.y,player2Selector.position.z),Time.deltaTime*10);
			break;
		case 2:
			player2Selector.position = Vector3.Lerp (player2Selector.position, new Vector3(player2SelectorPos1.position.x,player1SelectorPos2.position.y,player2Selector.position.z),Time.deltaTime*10);
			break;
		case 3:
			player2Selector.position = Vector3.Lerp (player2Selector.position, new Vector3(player2SelectorPos1.position.x,player1SelectorPos3.position.y,player2Selector.position.z),Time.deltaTime*10);
			break;
		default:
			break;
		}
	}
}
