using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {
	public int temperature = 0;
	public int precipitation = 0;
	public int windSpeed = 0;
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
				windDir = gameObject.transform.forward;
				awaitWindCapture = false;
			}
		}

		windForce = windDir * windSpeed;
	}

	//methods to change weather tied to bones
	//increases or decreases precipitation
	public void ChangePrecipitation(bool increase = true) {
	}

	//creates wind in the direction of the camera
	public void CreateWind(bool increase = true) {
		if (increase) {
			windSpeed++;
		} else {
			windSpeed--;
		}

		awaitWindCapture = true;
	}
}
