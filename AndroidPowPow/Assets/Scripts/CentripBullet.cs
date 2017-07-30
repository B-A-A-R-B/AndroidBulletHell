using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentripBullet : EnemyBulletMovement {

	public float f = 0.05f;
	public float sX = -15f;
	public float sY = 15f;
	// Use this for initialization
	void Start () {

		this.rigBod.velocity = new Vector2 (sX, sY);

	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate () {
		float a = this.rigBod.velocity.x;
		float b = this.rigBod.velocity.y;
		float angel = 0;

		if (a == 0) {
			if (b > 0)
				angel = Mathf.PI*3/2;
			if (b < 0)
				angel = Mathf.PI/2;
		} else
			angel = Mathf.Atan( b / a );
		float C = angel;
		Debug.Log (C);
		//C += 10;
		//this.rigBod.rotation = this.rigBod.rotation + f;
		Vector2 newDir = Vector2FromAngle (C + f, a > 0 ? 30f : -30f);
		this.rigBod.velocity = newDir;


	}

	Vector2 Vector2FromAngle(float a, float speed) {

		return new Vector2 (Mathf.Cos (a) * speed, Mathf.Sin (a) * speed);

	}
}
