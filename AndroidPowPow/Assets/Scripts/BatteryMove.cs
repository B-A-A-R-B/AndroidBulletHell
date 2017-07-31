using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour {
	protected Vector2 trajec;
	Rigidbody2D rigBod;
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
		trajec.x = CreateGlobals.enemyBulletSpeed;
		trajec = trajec / 25;
		rigBod.position = rigBod.position + trajec;


	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "BulletKill")
			Destroy (this.gameObject);
		if (collision.gameObject.tag == "Player") {
			AudioManager.Manager.Play ("Battery");
			CreateGlobals.batterChargeLevel = 100;
			Destroy (this.gameObject);

		}


	}
}
