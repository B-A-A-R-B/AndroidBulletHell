using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGlobals : MonoBehaviour {

	public static int enemyBulletSpeed = -3;
	public static int playerLaserSpeed = 9;
	public static int batterChargeLevel = 100;
	private float nextActionTime = 0.0f;
	public float period = 0.5f;
	public GameObject player;
	public static int deathCountDown = 0;

	// Use this for initialization


	void Start () {
		player = (GameObject)Instantiate (Resources.Load ("Player"));
		player.transform.position = new Vector2 (-70, 0);

	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextActionTime) {

			nextActionTime += period;

			if (deathCountDown <= 1)
				batterChargeLevel -= 1;
			else {
				deathCountDown--;
				if (deathCountDown <= 1) {
					player = (GameObject)Instantiate (Resources.Load ("Player"));
					player.transform.position = new Vector2 (-70, 0);
				}
			}
		}

		if (batterChargeLevel <= 0) {
			
			Destroy (player);
			batterChargeLevel = 101;
			deathCountDown = 20;


		}
	}
}