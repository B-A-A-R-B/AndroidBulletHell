using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveBullet : EnemyBulletMovement{
	protected int startY;
	protected int startD = -1;
	public float r = 10f;
	private float count = 0f;
	public float f = 10f;
	// Use this for initialization
	void Start () {

		startY = (int) this.rigBod.position.y;
		if (startY >= 0)
			startD = 1;

		this.rigBod.velocity = new Vector2 (-30, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		/*
		int distFrm = (int) (this.rigBod.position.y - startY);
		int nonZeroDist = distFrm;
		if (distFrm == 0)
			nonZeroDist = startD;
		
		trajec.x = CreateGlobals.enemyBulletSpeed / 2;
		trajec.y = (startD * CreateGlobals.enemyBulletSpeed) * r; // (nonZeroDist);
		trajec = trajec / 2;
		rigBod.position = rigBod.position + trajec;

		if (distFrm < 9 && startD == 1)
			startD = -1;

		if (distFrm > -9 && startD == -1)
			startD = 1;
			*/
		this.rigBod.velocity = new Vector2(this.rigBod.velocity.x, (Mathf.Cos (count * r)) * f);
		count++;

	}

}
