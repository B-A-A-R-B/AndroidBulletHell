using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour {

	List<GameObject> enemiesArray = new List<GameObject>();
	private int phase = 0;
	public int maxEnem = 3;
	protected System.Random rand = new System.Random ();
	private string[] enemyNames = {"Enemy1", "EnemySine", "EnemyCentrip"};

	void Start () {
		
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
			phase = rand.Next (1, maxEnem + 1);
			int enemTrack = 0;
			int maxX = 100 + (10 * (phase / 2));
			Vector2 startPos = new Vector2();
			EnemyMovement moveCont = new EnemyMovement();

			for (int i = 0; i < phase; i++) {
				
				createEnemy ();
				moveCont = (enemiesArray [i].GetComponent<EnemyMovement> ());
				startPos = (new Vector2 (maxX - (10 * (enemTrack / 2)), 0));
				moveCont.maxXPos = moveCont.maxXPos - (10 * (enemTrack / 2)); 
				moveCont.direction = phase % 2;
				enemiesArray [i].transform.position = startPos;
				if (phase % 2 == 1) {
					if (enemTrack % 2 == 0 && (enemTrack + 1) != phase)
						moveCont.maxLow = 0;
					else if ((enemTrack + 1) != phase)
						moveCont.maxHight = 0;
			
				} else {
					if (enemTrack % 2 == 0)
						moveCont.maxLow = 0;
					else
						moveCont.maxHight = 0;
				}
				enemTrack++;

			}

		}
	}

	void createEnemy() {

		int enemType = rand.Next (0, 3);
		GameObject enemNew = (GameObject)Instantiate (Resources.Load (enemyNames[enemType]));
		enemiesArray.Add (enemNew);

	}
}
