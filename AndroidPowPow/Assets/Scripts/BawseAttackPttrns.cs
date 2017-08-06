using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BawseAttackPttrns : MonoBehaviour {
	Rigidbody2D rigBod;
	public int startYCent;
	public int startYNorm;
	public int maxXPos = 58;
	private float startYMod = 0f;
	private bool yUp = false;
	private float nextActionTime;
	public float period = 0.5f;
	private int oneTwo = 0;
	private int waveAttackY = 0;
	private int cycleCen = 0;
	private int cycleNum = 10;
	private int cyclePos = -1;
	private int healthMax = 15;
	private int health;
	private int lives = 8;
	private bool invul = true;
	private bool started = false;
	private System.Random rand = new System.Random();
	private SpriteRenderer bawseFace;
	// Use this for initialization
	void Start () {
		nextActionTime = Time.time;
		rigBod = GetComponent<Rigidbody2D> ();
		bawseFace = GetComponent<SpriteRenderer> ();
		bawseFace.color = new Color (0f, 0f, 0f, 0.5f);
		CreateGlobals.bossHere = 1;
		health = healthMax;
		//PlayerMovement playerBox = CreateGlobals.player.GetComponent<PlayerMovement>();
		//playerBox.maxX = playerBox.maxX - 20;

	}
	
	// Update is called once per frame
	void Update () {
	
		//attackPttrnThree (waveAttackY);
		if (nextActionTime <= Time.time) {
			nextActionTime += period;
			if (started) {
				invul = false;
				bawseFace.color = new Color (1f, 1f, 1f, 1f);
			}
			//attackPttrnTwo ();
			if(rigBod.position.x <= 58)
				switch ((int)(lives)) {

				case 0:
					AudioManager.Manager.Play ("Explosion");
					Destroy (this.gameObject);
					SceneManager.LoadScene ("WinScene");
					break;
				case 1:
					waveAttackY = (((waveAttackY + 15) + 2) % 30) - 15;
					attackPttrnThree (waveAttackY + 20, false);
					attackPttrnThree ((waveAttackY + 20) * -1, true);
					oneTwo = 0;
					break;
				case 2:
					waveAttackY = (((waveAttackY + 15) + 2) % 30) - 15;
					attackPttrnThree (waveAttackY + 20, false);
					attackPttrnThree ((waveAttackY + 20) * -1, true);
					oneTwo = 0;
					break;
				case 3:
					//startYMod = 0f;
					attackPttrnFour ();
					break;
				case 4:
					startYMod = 0f;
					attackPttrnFour ();
					break;
				case 5:
					attackPttrnOne (true);
					break;
				case 6:
					attackPttrnOne (false);
					break;
				case 7:
					attackPttrnTwo ();
					break;
				case 8:
					startYMod = 0f;
					attackPttrnTwo ();
					break;
				default:
					oneTwo = -1;
					break;

			}
		}
		if (!started && (rigBod.position.x <= 58)) {
			invul = false;
			bawseFace.color = new Color (1f, 1f, 1f, 1f);
			started = true;
		}
		if ( rigBod.transform.position.x > maxXPos)
			rigBod.transform.position = ((Vector2)rigBod.transform.position) + ((new Vector2(-1,0)) / 4);
	}

	void attackPttrnOne (bool modVers) {

		GameObject[] bulletProj = new GameObject[4];
		DualCentrip[] bulletType = new DualCentrip[4];
		if (!modVers)
			for (int i = 0; i < bulletProj.Length; i++) {

				bulletProj [i] = (GameObject)Instantiate (Resources.Load ("EnemyBullet4"));
				bulletProj [i].transform.position = rigBod.position;
				bulletType [i] = bulletProj [i].GetComponent<DualCentrip> ();
				bulletType [i].startY = startYCent * (i + 1);
				bulletType [i].startPos = 0;
				//startY += startY;


			}
		else 
			for (int i = 0; i < bulletProj.Length; i++) {

				bulletProj [i] = (GameObject)Instantiate (Resources.Load ("EnemyBullet4"));
				bulletProj [i].transform.position = rigBod.position;
				bulletType [i] = bulletProj [i].GetComponent<DualCentrip> ();
				bulletType [i].startY = startYCent * (i + 1);
				bulletType [i].startPos = cyclePos;
				//startY += startY

			}
		if (cycleCen < cycleNum) {
			cycleCen++;
			cyclePos = -1;
		} else if (cycleCen < cycleNum*2) {
			cycleCen++;
			cyclePos = 0;
		} else if (cycleCen < cycleNum*3) {
			cycleCen++;
			cyclePos = 1;
		} else
			cycleCen = 0;
	}
	void attackPttrnTwo () {

		GameObject[] bulletProj = new GameObject[8];
		EnemyBulletMovement[] bulletType = new EnemyBulletMovement[8];
		for (int i = 0; i < bulletProj.Length; i += 2 ) {

			bulletProj[i] = (GameObject) Instantiate(Resources.Load("EnemyBullet"));
			bulletProj [i].transform.position = rigBod.position;
			bulletType [i] = bulletProj [i].GetComponent<EnemyBulletMovement> ();
			bulletType [i].startY = (startYNorm * ((i + 1)/2)) + (startYMod * startYNorm);
			bulletProj[i + 1] = (GameObject) Instantiate(Resources.Load("EnemyBullet"));
			bulletProj [i + 1].transform.position = rigBod.position;
			bulletType [i + 1] = bulletProj [i + 1].GetComponent<EnemyBulletMovement> ();
			bulletType [i + 1].startY = (startYNorm * ((i + 1)/ 2) * -1) + (startYMod * startYNorm);
			if(yUp)
				startYMod += 0.2f ;
			else
				startYMod -= 0.2f;
			if ((yUp && startYMod >= 6) || (!yUp && startYMod <= -6))
				yUp = !yUp;
			//Debug.Log(startYMod);

			//startY += startY;

		}

	}
	void attackPttrnThree (int ySpawn, bool neg) {

		GameObject bulletProj = new GameObject();
		SineWaveBullet bulletType = new SineWaveBullet();
		bulletProj = (GameObject) Instantiate(Resources.Load("EnemyBullet2"));
		Vector2 spawnPoint = new Vector2 (rigBod.position.x, ySpawn);
		bulletProj.transform.position = spawnPoint;
		if (!neg)
			bulletType.f *= -1;
	
	}
	void attackPttrnFour (){
		switch (oneTwo) {
		case 0:
			attackPttrnOne (false);
			oneTwo = 1;
			break;
		case 1:
			attackPttrnTwo ();
			oneTwo = 0;
			break;
		default:
			oneTwo = -1;
			break;
		}
	}
	void OnTriggerEnter2D (Collider2D collision) {

		if (collision.gameObject.tag == "PlayerLaser" && !invul) {
			AudioManager.Manager.Play ("Enemy");
			health--;
			if (health <= 0) {
				lives--;
				health = healthMax;
				cycleCen = 0;
				cyclePos = -1;
				GameObject batt = (GameObject)Instantiate (Resources.Load ("Batteries"));
				if (CreateGlobals.player != null) {
					Vector2 battSpawn = new Vector2 (rigBod.position.x, CreateGlobals.player.transform.position.y);
					bawseFace.color = new Color (1f, 1f, 1f, 0.5f);
					batt.transform.position = battSpawn;
					nextActionTime += (period * 12);
					invul = true;
				}

			}
		}
	}
}
