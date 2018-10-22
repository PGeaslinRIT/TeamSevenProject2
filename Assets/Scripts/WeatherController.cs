using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {
	public int temperature = 0;
	public int precipitation = 0;
	public int windSpeed = 0;
	private bool windIncrease = true;
	public Vector3 windDir = Vector3.zero;
	public Vector3 windForce = Vector3.zero;

	public bool awaitWindCapture = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (awaitWindCapture) {
				windDir = gameObject.transform.FindChild ("MainCamera").transform.forward;
				if (windIncrease) {
					windSpeed++;
				} else if (windSpeed > 0) {
					windSpeed--;
				}
				awaitWindCapture = false;
			}
		}

		windForce = windDir * windSpeed;
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
