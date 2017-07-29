﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour {

	Vector2 trajec;
	protected Rigidbody2D rigBod;
	List<Collider> colliders = new List<Collider>();

	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {

		trajec.x = CreateGlobals.enemyBulletSpeed / 2;
		trajec = trajec / 2;
		rigBod.position = rigBod.position + trajec;


	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "BulletKill")
			Destroy (this.gameObject);
		if (collision.gameObject.tag == "Player") {

			CreateGlobals.batterChargeLevel -= 20;
			Destroy (this.gameObject);

		}
			

	}
}
