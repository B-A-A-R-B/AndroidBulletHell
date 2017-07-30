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
		if (phaseNext) {
			phase++;

			switch (phase) {

			case 1:
				GameObject[] enemNew = new GameObject[3];
				enemNew [0] = (GameObject)Instantiate (Resources.Load ("EnemyCentrip"));
				enemNew [1] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				enemNew [2] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				for (int i = 0; i < 3; i++)
					enemiesArray.Add (enemNew [i]);
				enemiesArray [0].transform.position = new Vector2 (100, 0);
				enemiesArray [1].transform.position = new Vector2 (110, 10);
				EnemyMovement comp1 = enemiesArray [1].GetComponent<EnemyMovement> ();
				comp1.maxLow = 0;
				enemiesArray [2].transform.position = new Vector2 (110, -10);
				EnemyMovement comp2 = enemiesArray [2].GetComponent<EnemyMovement> ();
				comp2.maxHight = 0;
				comp2.direction = 1;
				break;

			case 2:
				break;

			default:
				break;

			}
			
		}

	}

	void FixedUpdate() {



		if (phase == 0) {
			if ((enemiesArray [0].transform.position.x) > 70)
				enemiesArray [0].transform.position = ((Vector2)enemiesArray [0].transform.position) + (advanceEnemy / 4);

		}
		if (phase == 1) {

			for (int i = 0; i < enemiesArray.Count; i++) {
				if (enemiesArray [i] != null) {
					if ((enemiesArray [i].transform.position.x) > 60 && i == 0)
						enemiesArray [i].transform.position = ((Vector2)enemiesArray [i].transform.position) + (advanceEnemy / 4);
					else if ((enemiesArray [i].transform.position.x) > 70)
						enemiesArray [i].transform.position = ((Vector2)enemiesArray [i].transform.position) + (advanceEnemy / 4);
				}
			}
		}
			
			//if ((enemiesArray [0].transform.position.x) > 75)
				//enemiesArray [0].transform.position = ((Vector2)enemiesArray [0].transform.position) + (advanceEnemy / 4);

	}
}
