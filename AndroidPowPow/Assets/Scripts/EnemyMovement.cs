using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	protected Rigidbody2D rigBod;
	protected int direction = 0;
	protected int maxHight;
	protected int maxWidth;
	protected int health;
	protected System.Random rand = new System.Random ();


	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();
		maxHight = 2 * ((int)Camera.main.orthographicSize);
		maxWidth =((int) ( Camera.main.aspect * Camera.main.orthographicSize ));
		health = 3;
		//direction = rand.Next (0, 2);

	}

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetMouseButtonDown (1))) {

			GameObject bulletProj = (GameObject)Instantiate (Resources.Load ("EnemyBullet"));
			bulletProj.transform.position = rigBod.position;

		}

	}

	void FixedUpdate() {

		Vector2 moving = Vector2.zero;

		if (direction == 1) {

			if (rigBod.position.y >= (maxHight - 5)/ 2) {

				direction = 0;

			} else {

				moving.y = 1;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;
			
			}

		}
		if (direction == 0) {

			if (rigBod.position.y <= ((-1 * (maxHight) ) + 5) /2) {

				direction = 1;

			} else {

				moving.y = -1;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;

			}

		}
		if (health <= 0)
			Destroy (this.gameObject);

	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "PlayerLaser")
			health--;

	}
}
