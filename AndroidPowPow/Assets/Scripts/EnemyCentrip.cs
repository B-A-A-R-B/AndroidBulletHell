using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCentrip : EnemyMovement {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetMouseButtonDown (1))) {

			GameObject bulletProj = (GameObject)Instantiate (Resources.Load ("EnemyBullet3"));
			bulletProj.transform.position = rigBod.position;

		}

	}
}
