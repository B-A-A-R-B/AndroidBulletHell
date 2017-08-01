using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColorTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUIText story = GetComponent<GUIText> ();
		story.text = story.text + "\n THIS. IS. POWER STRUGGLE.";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
