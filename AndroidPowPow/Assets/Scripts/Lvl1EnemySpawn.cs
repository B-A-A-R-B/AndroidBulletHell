using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1EnemySpawn : MonoBehaviour {

	List<GameObject> enemiesArray = new List<GameObject>();
	int phase = 0;
	protected string checkOne;
	Vector2 advanceEnemy = new Vector2(-1, 0);
	// Use this for initialization
	void Start () {

		GameObject enemNew = (GameObject)Instantiate (Resources.Load ("Enemy1"));
		enemiesArray.Add (enemNew);
		enemNew = (GameObject)Instantiate (Resources.Load ("Enemy1"));
		enemiesArray.Add (enemNew);
		Vector2 startPos = new Vector2 (100, 20);
		Vector2 startPos2 = new Vector2 (100, -20);
		enemiesArray [0].transform.position = startPos;
		enemiesArray [1].transform.position = startPos2;
		EnemyMovement comp1 = enemiesArray [0].GetComponent<EnemyMovement> ();
		comp1.maxLow = 0;
		EnemyMovement comp2 = enemiesArray [1].GetComponent<EnemyMovement> ();
		comp2.maxHight = 0;
		comp2.direction = 1;


	}
	
	// Update is called once per frame
	void Update () {
		bool phaseNext = true;
		int deletWhich = -1;
		for (int i = 0; i < enemiesArray.Count; i++) {

			if (enemiesArray [i] == null)
				deletWhich = i;//enemiesArray.Remove (enemiesArray [i]);
			else
				phaseNext = false;
		
		}
		if (deletWhich >= 0)
			enemiesArray.Remove (enemiesArray [deletWhich]);

		if (phaseNext) {
			phase++;

			switch (phase) {

			case 1:
				GameObject bossNew = new GameObject ();
				bossNew = (GameObject)Instantiate (Resources.Load ("BawseEnemy"));
				enemiesArray.Add (bossNew);
				enemiesArray [0].transform.position = new Vector2 (110, 0);
				break;

		/*	case 1:
				GameObject[] enemNew = new GameObject[4];
				enemNew [0] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				enemNew [1] = (GameObject)Instantiate (Resources.Load ("EnemyCentrip"));
				enemNew [2] = (GameObject)Instantiate (Resources.Load ("EnemyCentrip"));
				enemNew [3] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				for (int i = 0; i < enemNew.Length; i++)
					enemiesArray.Add (enemNew [i]);
				enemiesArray [0].transform.position = new Vector2 (110, 20);
				checkOne = enemiesArray [0].name;
				EnemyMovement comp1 = enemiesArray [0].GetComponent<EnemyMovement> ();
				comp1.maxLow = 0;
				enemiesArray [1].transform.position = new Vector2 (100, 20);
				EnemyMovement comp2 = enemiesArray [1].GetComponent<EnemyMovement> ();
				comp2.maxLow = 0;
				enemiesArray [2].transform.position = new Vector2 (100, -20);
				EnemyMovement comp3 = enemiesArray [2].GetComponent<EnemyMovement> ();
				comp3.maxHight = 0;
				comp3.direction = 1;
				enemiesArray [3].transform.position = new Vector2 (110, -20);
				EnemyMovement comp4 = enemiesArray [3].GetComponent<EnemyMovement> ();
				comp4.maxHight = 0;
				comp4.direction = 1;
				break;

			case 2:
				GameObject[] enemNew2 = new GameObject[3];
				enemNew2 [0] = (GameObject)Instantiate (Resources.Load ("EnemySine"));
				enemNew2 [1] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				enemNew2 [2] = (GameObject)Instantiate (Resources.Load ("Enemy1"));
				for (int i = 0; i < 3; i++)
					enemiesArray.Add (enemNew2 [i]);
				enemiesArray [0].transform.position = new Vector2 (100, 0);
				checkOne = enemiesArray [0].name;
				EnemyMovement lomp0 = enemiesArray [0].GetComponent<EnemyMovement> ();
				lomp0.maxFireTime = 0.1;
				lomp0.minFireTime = 0.1;
				enemiesArray [1].transform.position = new Vector2 (110, 10);
				EnemyMovement lomp1 = enemiesArray [1].GetComponent<EnemyMovement> ();
				lomp1.maxLow = 0;
				enemiesArray [2].transform.position = new Vector2 (110, -10);
				EnemyMovement lomp2 = enemiesArray [2].GetComponent<EnemyMovement> ();
				lomp2.maxHight = 0;
				lomp2.direction = 1;
				break;
			case 3:
				GameObject bossNew = new GameObject ();
				bossNew = (GameObject)Instantiate (Resources.Load ("BawseEnemy"));
				enemiesArray.Add (bossNew);
				enemiesArray [0].transform.position = new Vector2 (110, 0);
				break;
*/
			default:
				break;

			}
			
		}

	}

	void FixedUpdate() {



		if (phase == 0) {
			for(int i = 0; i < enemiesArray.Count;  i++)
				if ((enemiesArray [i].transform.position.x) > 70)
					enemiesArray [i].transform.position = ((Vector2)enemiesArray [i].transform.position) + (advanceEnemy / 4);

		}
		if (phase == 1) {

			for (int i = 0; i < enemiesArray.Count; i++) {
				if (enemiesArray [i] != null) {
					if (((enemiesArray [i].transform.position.x) > 58) & (enemiesArray[i].name != checkOne))
						enemiesArray [i].transform.position = ((Vector2)enemiesArray [i].transform.position) + (advanceEnemy / 4);
					else if ((enemiesArray [i].transform.position.x) > 70)
						enemiesArray [i].transform.position = ((Vector2)enemiesArray [i].transform.position) + (advanceEnemy / 4);
				}
			}

		}
		if (phase == 2) {

			for (int i = 0; i < enemiesArray.Count; i++) {
				if (enemiesArray [i] != null) {
					if ((enemiesArray [i].transform.position.x) > 60 && (enemiesArray[i].name == checkOne))
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
