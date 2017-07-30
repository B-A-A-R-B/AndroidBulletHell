using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	public float speed = 1f;
	public float reposition;

	// Use this for initialization
	void Start () {
		float startingOffset;
		SpriteRenderer sprite;
		sprite = this.GetComponent<SpriteRenderer> ();
		startingOffset = this.transform.position.x;
		if (startingOffset > sprite.bounds.size.x)
			reposition = startingOffset;
		else
			reposition = startingOffset + sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (-1 * speed, 0));
	}

	void OnBecameInvisible () {
		this.transform.position = new Vector3 (repositiongit, 0);
	}
}
