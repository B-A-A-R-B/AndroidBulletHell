using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BawseAttackPttrns : MonoBehaviour {
	Rigidbody2D rigBod;
	public int startY;
	private float nextActionTime;
	public float period = 0.5f;
	// Use this for initialization
	void Start () {
		nextActionTime = Time.time;
		rigBod = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (nextActionTime <= Time.time) {
			nextActionTime += period;
			attackPttrnOne ();
		}
	}

	void attackPttrnOne () {

		GameObject[] bulletProj = new GameObject[4];
		DualCentrip[] bulletType = new DualCentrip[4];
		for (int i = 0; i < bulletProj.Length; i++) {

			bulletProj[i] = (GameObject) Instantiate(Resources.Load("EnemyBullet4"));
			bulletProj [i].transform.position = rigBod.position;
			bulletType [i] = bulletProj [i].GetComponent<DualCentrip> ();
			bulletType [i].startY = startY * (i + 1);
			//startY += startY;
			
		}

	}
}
