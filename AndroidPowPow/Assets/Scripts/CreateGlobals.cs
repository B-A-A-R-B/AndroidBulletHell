using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreateGlobals : MonoBehaviour {

	public static int enemyBulletSpeed = -3;
	public static int playerLaserSpeed = 9;
	public static int batterChargeLevel = 100;
	private float nextActionTime = 0.0f;
	public float period = 0.5f;
	public GameObject player;
	public static int deathCountDown = 0;
	protected bool r;

	// Use this for initialization


	void Start () {
		player = (GameObject)Instantiate (Resources.Load ("Player"));
		player.transform.position = new Vector2 (-70, 0);
		nextActionTime = Time.time;

	}

	// Update is called once per frame
	void Update () {

		if ((r = Input.GetKey ("r") || Input.GetKeyDown ("r")) && deathCountDown >= 1) {
			SceneManager.LoadScene ("Cityscape");
			deathCountDown = 0;
		}

		if (Time.time > nextActionTime) {

			nextActionTime += period;

			if (deathCountDown <= 1)
				batterChargeLevel -= 1;
			else {
				deathCountDown--;
				//if (r) {
					//SceneManager.LoadScene ("Cityscape");
					//deathCountDown = 0;
					//r = false;} else
				if (deathCountDown <= 1) {
					batterChargeLevel = 100;
					SceneManager.LoadScene ("MainMenu");
					//player = (GameObject)Instantiate (Resources.Load ("Player"));
					//player.transform.position = new Vector2 (-70, 0);
				}
			}
		}

		if (batterChargeLevel <= 0) {
			AudioManager.Manager.Play ("Explosion");
			Destroy (player);
			batterChargeLevel = 101;
			deathCountDown = 20;


		}
	}

	void PlaySE() {
	}
}