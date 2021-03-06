using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Manager { get; set; }

	// Use this for initialization
	void Start () {
		Manager = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(string tag) {
		AudioSource[] sources = GetComponentsInChildren<AudioSource> ();
		foreach (AudioSource src in sources)
			if (src.tag == tag)
				src.Play ();
	}
}
