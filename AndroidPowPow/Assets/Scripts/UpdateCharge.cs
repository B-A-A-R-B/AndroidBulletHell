using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCharge : MonoBehaviour {

	public Text chargeLabel;

	// Use this for initialization
	void Start () {
		
		chargeLabel = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {


		if (CreateGlobals.batterChargeLevel <= 100)
			chargeLabel.text = CreateGlobals.batterChargeLevel + "%";
		else
			chargeLabel.text = (CreateGlobals.deathCountDown/ 2).ToString();
	}
}
