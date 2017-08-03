using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour {

	public Vector2 trajec;
	public float startY;
	public Rigidbody2D rigBod;
	//List<Collider> colliders = new List<Collider>();
	protected float timed = 60f;
	float startTime;
	void OnEnable() {

		rigBod = GetComponent<Rigidbody2D> ();


	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime == 0)
			startTime = Time.time;
		if (Time.time > (timed + startTime))
			Destroy (this.gameObject);

	}
	void FixedUpdate () {
		//trajec.x = ((CreateGlobals.enemyBulletSpeed) - ((int)startY/5)) / 2;
		//trajec.y = ((startY / 5) / 2);
		//trajec = trajec / 2;
		//rigBod.position = rigBod.position + trajec;
		this.rigBod.velocity = new Vector2( 5 , startY);
		rigBod.velocity = this.rigBod.velocity.normalized;
		trajec.x = this.rigBod.velocity.x * CreateGlobals.enemyBulletSpeed;
		trajec.y = this.rigBod.velocity.y * CreateGlobals.enemyBulletSpeed;
		this.rigBod.velocity = trajec;

	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "BulletKill")
			Destroy (this.gameObject);
		if (collision.gameObject.tag == "Player" && !CreateGlobals.playerInvul) {
			AudioManager.Manager.Play ("Player");
			CreateGlobals.batterChargeLevel -= 25;
			Destroy (this.gameObject);
			CreateGlobals.playerInvul = true;
			CreateGlobals.sprRndrPlayer.color = new Color (1f, 1f, 1f, 0.5f);
			CreateGlobals.playerNotInvul = Time.time + 1f;

		} else if(collision.gameObject.tag == "Player")
			Destroy (this.gameObject);
			

	}
}
