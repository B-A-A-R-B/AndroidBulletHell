using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour {

	//public Button startButton;
	// Use this for initialization
	void Start () {

		Button btn = this.GetComponent<Button> ();
		//btn.onClick.AddListener (LoadStage);

	}
	
	// Update is called once per frame
	void Update () {



	}
	public void LoadStage() {

		SceneManager.LoadScene ("Cityscape");

	}

}
