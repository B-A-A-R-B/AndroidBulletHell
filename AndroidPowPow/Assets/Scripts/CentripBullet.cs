using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentripBullet : EnemyBulletMovement {

	public float f = 10f;
	// Use this for initialization
	void Start () {

		this.rigBod.velocity = new Vector2 (-30, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		/*
		float a = this.rigBod.velocity.x;
		float b = this.rigBod.velocity.y;
		float c = Mathf.Sqrt ((a * a) + (b * b));
		float A = ((b ^ 2) + (c ^ 2) - (a ^ 2)) / (2 * b * c);
		//this.rigBod.rotation = this.rigBod.rotation + f;
		Vector2 newDir = Vector2FromAngle (this.rigBod.rotation);
		//newDir *= -30;
		//this.rigBod.velocity = newDir;
		*/

	}

	Vector2 Vector2FromAngle(float a) {

		a *= Mathf.Deg2Rad;
		return new Vector2 (Mathf.Cos (a), Mathf.Sin (a));

	}
}
