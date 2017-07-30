using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCentrip : MonoBehaviour {
	public string bulletType = "EnemyBullet3";
	protected Rigidbody2D rigBod;
	public int startY;

	// Use this for initialization
	void Start () {

		rigBod = GetComponent<Rigidbody2D> ();
		GameObject bulletProj1 = (GameObject)Instantiate (Resources.Load (bulletType));
		GameObject bulletProj2 = (GameObject)Instantiate (Resources.Load (bulletType));
		CentripBullet proj1Cent = bulletProj1.GetComponent<CentripBullet> ();
		CentripBullet proj2Cent = bulletProj2.GetComponent<CentripBullet> ();
		bulletProj1.transform.position = rigBod.position;
		bulletProj2.transform.position = rigBod.position;
		proj1Cent.sY = startY;
		proj2Cent.sY = 0 - startY;
		proj1Cent.f *= -1f;
		Destroy (this);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
