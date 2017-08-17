using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreateGlobals : MonoBehaviour {

	public static bool gameInput = false;
	public static int enemyBulletSpeed = -25;
	public static int playerLaserSpeed = 9;
	public static int batterChargeLevel = 100;
	private float nextActionTime = 0.0f;
	public static float playerNotInvul = 0.0f;
	public static float period = 0.5f;
	public static GameObject player;
	public static SpriteRenderer sprRndrPlayer;
	public static int deathCountDown = 0;
	public static int bossHere = 0;
	protected bool r;
	public static bool playerInvul = false;

	// Use this for initialization


	void Start () {
		
		player = (GameObject)Instantiate (Resources.Load ("Player"));
		player.transform.position = new Vector2 (-70, 0);
		PlayerMovement playerScr = player.GetComponent<PlayerMovement>();
		playerScr.gamePad = gameInput;
		nextActionTime = Time.time;
		sprRndrPlayer = player.GetComponent<SpriteRenderer> ();

	}

	// Update is called once per frame
	void Update () {

		if ((r = Input.GetKey ("r") || Input.GetKeyDown ("r")) && deathCountDown >= 1) {
			Scene current = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (current.name);
			deathCountDown = 0;
			bossHere = 0;
		}

		if (Time.time > nextActionTime && !playerInvul) {

			nextActionTime += period;

			if (deathCountDown <= 1) {
				deathCountDown = 0;
				batterChargeLevel -= 1;
			} else {
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
		} else if (playerInvul && Time.time >= playerNotInvul) {
			playerInvul = false;
			nextActionTime = Time.time + period;
			if(sprRndrPlayer != null)
				sprRndrPlayer.color = new Color (1f, 1f, 1f, 1f);
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