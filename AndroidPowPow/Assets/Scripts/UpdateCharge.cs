using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCharge : MonoBehaviour {

	public Text chargeLabel;
	public Image energyBar;
	private float bar_max_width;

	// Use this for initialization
	void Start () {
		
		chargeLabel = GetComponent<Text>();
		Image[] images = GetComponentsInChildren<Image> ();
		foreach (Image img in images) {
			if (img.transform.name == "EnergyBar") {
				energyBar = img;
				bar_max_width = energyBar.rectTransform.sizeDelta.x;
			}
		}

	
	}
	
	// Update is called once per frame
	void Update () {


		if (CreateGlobals.batterChargeLevel <= 100) {
			chargeLabel.text = "";
			energyBar.rectTransform.sizeDelta = new Vector2 ((float)CreateGlobals.batterChargeLevel / 100 * bar_max_width, energyBar.rectTransform.sizeDelta.y);
		} else {
			chargeLabel.text = (CreateGlobals.deathCountDown / 2).ToString ();
			energyBar.rectTransform.sizeDelta = new Vector2 (0f, energyBar.rectTransform.sizeDelta.y);
		}
		
	}
}
