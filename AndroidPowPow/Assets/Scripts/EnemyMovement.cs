using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	protected Rigidbody2D rigBod;
	protected int direction;
	protected int maxHight;
	protected int maxWidth;
	protected System.Random rand = new System.Random ();


	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();

	}

	void Start () {

		maxHight = 2 * ((int)Camera.main.orthographicSize);
		maxWidth =((int) ( Camera.main.aspect * Camera.main.orthographicSize ));
		direction = rand.Next (0, 2);

	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetMouseButtonDown (1))) {

			GameObject bulletProj = (GameObject)Instantiate (Resources.Load ("EnemyBullet"));
			bulletProj.transform.position = rigBod.position;

		}

	}

	void UpdateFixed () {

		Vector2 moving = Vector2.zero;

		if (direction == 1) {

			if (rigBod.position.y >= (maxHight - 5)) {

				direction = 0;

			} else {

				moving.y = 1;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;
			
			}

		}
		if (direction == 0) {

			if (rigBod.position.y >= (maxHight - 5)) {

				direction = 1;

			} else {

				moving.y = -1;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;

			}

		}


	}
}
