using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
	public static bool endlessUnlocked;

	void Start(){
		endlessUnlocked = false;
		DontDestroyOnLoad (this.transform.gameObject);
	}

}
