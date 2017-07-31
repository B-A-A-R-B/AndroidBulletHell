﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BawseAttackPttrns : MonoBehaviour {
	Rigidbody2D rigBod;
	public int startYCent;
	public int startYNorm;
	private float nextActionTime;
	public float period = 0.5f;
	private int oneTwo = 0;
	private int waveAttackY = 0;
	private int health = 15;
	private int lives = 4;
	private System.Random rand = new System.Random();
	// Use this for initialization
	void Start () {
		nextActionTime = Time.time;
		rigBod = GetComponent<Rigidbody2D> ();
		CreateGlobals.bossHere = 1;
		//PlayerMovement playerBox = CreateGlobals.player.GetComponent<PlayerMovement>();
		//playerBox.maxX = playerBox.maxX - 20;

	}
	
	// Update is called once per frame
	void Update () {
	
		//attackPttrnThree (waveAttackY);
		if (nextActionTime <= Time.time) {
			nextActionTime += period;

			//attackPttrnTwo ();
			if(rigBod.position.x <= 58) 
				switch (lives) {

				case 0:
					AudioManager.Manager.Play ("Explosion");
					Destroy (this.gameObject);
					break;
				case 1:
					waveAttackY = (((waveAttackY + 15) + 2) % 30) - 15;
					attackPttrnThree (waveAttackY + 20, false);
					attackPttrnThree ((waveAttackY + 20) * -1, true);
					oneTwo = 0;
					break;
				case 2:
					attackPttrnFour ();
					break;
				case 3:
					attackPttrnOne ();
					break;
				case 4:
					attackPttrnTwo ();
					break;
				default:
					oneTwo = -1;
					break;

			}
		}
	}

	void attackPttrnOne () {

		GameObject[] bulletProj = new GameObject[4];
		DualCentrip[] bulletType = new DualCentrip[4];
		for (int i = 0; i < bulletProj.Length; i++) {

			bulletProj[i] = (GameObject) Instantiate(Resources.Load("EnemyBullet4"));
			bulletProj [i].transform.position = rigBod.position;
			bulletType [i] = bulletProj [i].GetComponent<DualCentrip> ();
			bulletType [i].startY = startYCent * (i + 1);
			//startY += startY;
			
		}

	}
	void attackPttrnTwo () {

		GameObject[] bulletProj = new GameObject[8];
		EnemyBulletMovement[] bulletType = new EnemyBulletMovement[8];
		for (int i = 0; i < bulletProj.Length; i += 2 ) {

			bulletProj[i] = (GameObject) Instantiate(Resources.Load("EnemyBullet"));
			bulletProj [i].transform.position = rigBod.position;
			bulletType [i] = bulletProj [i].GetComponent<EnemyBulletMovement> ();
			bulletType [i].startY = startYNorm * ((i + 1)/2);
			bulletProj[i + 1] = (GameObject) Instantiate(Resources.Load("EnemyBullet"));
			bulletProj [i + 1].transform.position = rigBod.position;
			bulletType [i + 1] = bulletProj [i + 1].GetComponent<EnemyBulletMovement> ();
			bulletType [i + 1].startY = startYNorm * ((i + 1)/ 2) * -1;
			//startY += startY;

		}

	}
	void attackPttrnThree (int ySpawn, bool neg) {

		GameObject bulletProj = new GameObject();
		SineWaveBullet bulletType = new SineWaveBullet();
		bulletProj = (GameObject) Instantiate(Resources.Load("EnemyBullet2"));
		Vector2 spawnPoint = new Vector2 (rigBod.position.x, ySpawn);
		bulletProj.transform.position = spawnPoint;
		if (!neg)
			bulletType.f *= -1;
	
	}
	void attackPttrnFour (){
		switch (oneTwo) {
		case 0:
			attackPttrnOne ();
			oneTwo = 1;
			break;
		case 1:
			attackPttrnTwo ();
			oneTwo = 0;
			break;
		default:
			oneTwo = -1;
			break;
		}
	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "PlayerLaser" && rigBod.position.x <= 58) {
			AudioManager.Manager.Play ("Enemy");
			health--;
			if (health <= 0) {
				lives--;
				health = 15;
				GameObject batt = (GameObject)Instantiate (Resources.Load ("Batteries"));
				if (CreateGlobals.player != null) {
					Vector2 battSpawn = new Vector2 (rigBod.position.x, CreateGlobals.player.transform.position.y);
					batt.transform.position = battSpawn;
				}

			}
		}
	}
}