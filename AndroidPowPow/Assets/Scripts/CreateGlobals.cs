using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGlobals : MonoBehaviour {

	public static int enemyBulletSpeed = -3;
	public static int playerLaserSpeed = 6;
	public static int batterChargeLevel = 100;
	private float nextActionTime = 0.0f;
	public float period = 0.5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextActionTime) {

			nextActionTime += period;
			batterChargeLevel -= 1;


		}

	}
}