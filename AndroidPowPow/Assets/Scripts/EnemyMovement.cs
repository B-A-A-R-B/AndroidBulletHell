using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	protected Rigidbody2D rigBod;
	public int direction = 0;
	public int maxHight = 40;
	public int maxLow = -40;
	public int speed = 1;
	public int maxXPos = 70;
	protected int health;
	protected System.Random rand = new System.Random ();
	public string bulletType = "EnemyBullet"; 
	protected double attackRng;
	public double maxFireTime = 3;
	public double minFireTime = 1.5;
	private double nextActionTime = 0.0;
	private double enemyIndex;
	private bool invul;
	private float posLast;
	private SpriteRenderer sprRndr;
	//public double periode = 0;


	void OnEnable() {
		enemyIndex = (double) (this.GetInstanceID());
		nextActionTime = Time.time;
		int range = (int)((maxFireTime - minFireTime) * 100);
		attackRng = (rand.Next (0, range)); //100) + minFireTime;
		attackRng *= enemyIndex;
		attackRng =(double) (attackRng % 100);
		attackRng = attackRng / 100;
		attackRng += minFireTime;
		nextActionTime += attackRng;
		rigBod = GetComponent<Rigidbody2D> ();
		sprRndr = GetComponent<SpriteRenderer> ();
		//maxHight = 2 * ((int)Camera.main.orthographicSize);
		//maxWidth =((int) ( Camera.main.aspect * Camera.main.orthographicSize ));
		health = 3;
		invul = true;
		posLast = 400f;
		sprRndr.color = new Color (1f, 1f, 1f, 0.5f);
		//direction = rand.Next (0, 2);

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//attackRng = ((rand.Next(0,51)) /100) + 0.5;

		if (Time.time > (nextActionTime + attackRng) && !invul) {  //(Input.GetMouseButtonDown (1))) {
			int range = (int)((maxFireTime - minFireTime) * 100);
			attackRng = ((rand.Next (0, range)) / 100) + minFireTime;
			nextActionTime += attackRng;
			GameObject bulletProj = (GameObject)Instantiate (Resources.Load (bulletType));
			bulletProj.transform.position = rigBod.position;
			sprRndr.color = new Color (1f, 1f, 1f, 1f);

		} else if (Time.time > (nextActionTime + attackRng)) {

			int range = (int)((maxFireTime - minFireTime) * 100);
			attackRng = ((rand.Next (0, range)) / 100) + minFireTime;
			nextActionTime += attackRng;
			//sprRndr.color = new Color (1f, 1f, 1f, 0.5f);

		}

	}

	void FixedUpdate() {

		Vector2 moving = Vector2.zero;

		if (invul && posLast == rigBod.position.x)
			invul = false;

		posLast = rigBod.position.x;

		if (direction == 1) {

			if (rigBod.position.y >= maxHight - 5) {

				direction = 0;

			} else {

				moving.y = speed;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;
			
			}

		}
		if (direction == 0) {

			if (rigBod.position.y <= maxLow + 5) {

				direction = 1;

			} else {

				moving.y = -speed;
				moving = moving / 2;
				rigBod.position = rigBod.position + moving;

			}

		}


		if (rigBod.transform.position.x > maxXPos)
			rigBod.transform.position = ((Vector2)rigBod.transform.position) + ((new Vector2(-1,0)) / 4) + moving;

		if (health <= 0) {
			AudioManager.Manager.Play ("Explosion");
			//GameObject batt = (GameObject)Instantiate (Resources.Load ("Batteries"));
			//batt.transform.position = rigBod.position;
			Destroy (this.gameObject);

		}

	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "PlayerLaser" && !invul) {
			AudioManager.Manager.Play ("Enemy");
			health--;
			if (health <= 0) {
				GameObject batt = (GameObject)Instantiate (Resources.Load ("Batteries"));
				batt.transform.position = rigBod.position;
		
			}
		}
		if (collision.gameObject.tag == "Player" && !invul && !CreateGlobals.playerInvul) {
			CreateGlobals.batterChargeLevel -= 50;
			health = 0;
		}

	}

}
