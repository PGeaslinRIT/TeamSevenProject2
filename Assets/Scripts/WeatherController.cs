using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {
	public int temperature = 0;
	public int precipitation = 0;

	//wind variables
	public int windSpeed = 0;
	private bool windIncrease = true;
	public Vector3 windDir = Vector3.zero;
	public Vector3 windForce = Vector3.zero;
	public int windMax = 0;
	public bool awaitWindCapture = false;

	public int timePassed = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update once per frame
	void Update () {
		//collect data from clicking
		if (Input.GetMouseButtonDown(0)) {
			//wind direction
			if (awaitWindCapture) {
				windDir = gameObject.transform.FindChild ("MainCamera").transform.forward;
				if (windIncrease) {
					windSpeed++;
					windMax += 250;
				} else if (windSpeed > 0) {
					windSpeed--;
				}
				awaitWindCapture = false;
			}
		}

		//decrease how long wind lasts
		if (windMax > 0) {
			windMax--;

			if (windMax == 0) {
				windSpeed--;
			}
		}

		windForce = windDir * windSpeed;

		timePassed++;
	}

	//methods to change weather tied to bones

	//creates wind in the direction of the camera
	public void ChangeWind(bool increase = true) {
		windIncrease = increase;

		awaitWindCapture = true;

		Debug.Log ("Awaiting wind capture");
	}

	//increases or decreases precipitation
	public void ChangePrecipitation(bool increase = true) {
	}

	//increases or decreases temperature
	public void ChangeTemperature(bool increase = true) {
	}

	//creates lightning
	public void CreateLightning() {}

	//
}
