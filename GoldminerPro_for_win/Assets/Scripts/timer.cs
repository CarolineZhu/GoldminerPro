using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public float valueRemaining;
	public float valueMaximum;
//	public float valueConsumptionRate = 1f;

	public Text Timertext;
	public bool gameInProgress = true;

	// Use this for initialization
	void Start () {
		valueRemaining = 45;
		valueMaximum = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameInProgress) {
			valueRemaining -= Time.deltaTime;
			Timertext.text = "Time Remaining: " + Mathf.Round(valueRemaining).ToString();
			if (valueRemaining < 0) {
				gameInProgress = false;

			}
		}
	}
}
