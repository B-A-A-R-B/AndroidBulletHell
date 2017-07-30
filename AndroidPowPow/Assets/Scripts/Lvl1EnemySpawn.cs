using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1EnemySpawn : MonoBehaviour {

	List<GameObject> enemiesArray = new List<GameObject>();
	int phase = 0;
	Vector2 advanceEnemy = new Vector2(-1, 0);
	// Use this for initialization
	void Start () {

		GameObject enemNew = (GameObject)Instantiate (Resources.Load ("Enemy1"));
		enemiesArray.Add (enemNew);
		Vector2 startPos = new Vector2 (100, 0);
		enemiesArray [0].transform.position = startPos;

	}
	
	// Update is called once per frame
	void Update () {
		bool phaseNext = true;
		for (int i = 0; i < enemiesArray.Count; i++) {

			if (enemiesArray [i] == null)
				enemiesArray.Remove (enemiesArray [i]);
			else
				phaseNext = false;
		
		}
		if (phaseNext)
			phase++;

	}

	void FixedUpdate() {



		if (phase == 0) {
			if ((enemiesArray [0].transform.position.x) > 70)
				enemiesArray [0].transform.position = ((Vector2)enemiesArray [0].transform.position) + (advanceEnemy / 4);

		}

	}
}
