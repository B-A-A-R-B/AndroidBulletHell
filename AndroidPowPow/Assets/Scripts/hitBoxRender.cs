using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxRender : MonoBehaviour {
	SpriteRenderer hitBoxColor;
	// Use this for initialization
	void Start () {
		hitBoxColor = this.GetComponent<SpriteRenderer> ();
		hitBoxColor.color = new Color (0.3f, 0.6f, 0.9f, 0.55f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
