using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCentrip : MonoBehaviour {
	public string bulletType = "EnemyBullet3";
	protected Rigidbody2D rigBod;
	public int startY;
	public int startPos = 0;

	// Use this for initialization
	void Start () {

		if (startPos == 0) {
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
		if (startPos == 1) {
			rigBod = GetComponent<Rigidbody2D> ();
			GameObject bulletProj1 = (GameObject)Instantiate (Resources.Load (bulletType));
			GameObject bulletProj2 = (GameObject)Instantiate (Resources.Load (bulletType));
			CentripBullet proj1Cent = bulletProj1.GetComponent<CentripBullet> ();
			CentripBullet proj2Cent = bulletProj2.GetComponent<CentripBullet> ();
			bulletProj1.transform.position = new Vector2 (rigBod.position.x, rigBod.position.y - 20);
			bulletProj2.transform.position = new Vector2 (rigBod.position.x, rigBod.position.y - 20);
			proj1Cent.sY = startY * 2;
			proj2Cent.sY = -startY/ 2;
			proj1Cent.f *= -1f;
			Destroy (this);
		}
		if (startPos == -1) {
			rigBod = GetComponent<Rigidbody2D> ();
			GameObject bulletProj1 = (GameObject)Instantiate (Resources.Load (bulletType));
			GameObject bulletProj2 = (GameObject)Instantiate (Resources.Load (bulletType));
			CentripBullet proj1Cent = bulletProj1.GetComponent<CentripBullet> ();
			CentripBullet proj2Cent = bulletProj2.GetComponent<CentripBullet> ();
			bulletProj1.transform.position = new Vector2 (rigBod.position.x, rigBod.position.y + 20);
			bulletProj2.transform.position = new Vector2 (rigBod.position.x, rigBod.position.y + 20);
			proj1Cent.sY = startY / 2;
			proj2Cent.sY = -2*startY;
			proj1Cent.f *= -1f ;
			//proj2Cent.f *= 2f;
			Destroy (this);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
