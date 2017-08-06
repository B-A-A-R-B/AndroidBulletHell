using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour {
	public static string gameType = "CityScape";
	//public Button startButton;
	// Use this for initialization
	void Start () {

		Button btn = this.GetComponent<Button> ();
		//btn.onClick.AddListener (LoadStage);

	}
	
	// Update is called once per frame
	void Update () {



	}
	public void LoadInputSelect() {
		SceneManager.LoadScene ("InputSelect");
		StartGame.gameType = "Endless";
	}
	public void LoadStageGamePad() {

		SceneManager.LoadScene (gameType);
		CreateGlobals.gameInput = true;

	}
	public void LoadStageKeyBoard() {

		SceneManager.LoadScene (gameType);
		CreateGlobals.gameInput = false;

	}

}
