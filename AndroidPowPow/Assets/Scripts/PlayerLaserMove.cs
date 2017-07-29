using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaserMove : MonoBehaviour {

	Vector2 trajec;
	int new_proj = 0;
	protected Rigidbody2D rigBod;
	List<Collider> colliders = new List<Collider>();

	// Use this for initialization
	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();
			
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		trajec.x = CreateGlobals.playerLaserSpeed/2; //new_proj;
		rigBod.position = rigBod.position + trajec;


	}
	void OnTriggerEnter2D (Collider2D collision) {
	
		if (collision.gameObject.tag == "BulletKill")
			Destroy (this.gameObject);

	}
}