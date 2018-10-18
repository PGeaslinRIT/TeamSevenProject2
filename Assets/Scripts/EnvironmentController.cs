using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {
	//player weather controller
	public GameObject playerObj;
	public WeatherController thisWeatherController;

	//forces
	public Vector3 windForce;


	// Use this for initialization
	void Start () {
		thisWeatherController = playerObj.GetComponent<WeatherController> ();
	}
	
	// Update is called once per frame
	void Update () {
		windForce = thisWeatherController.windForce;

		playerObj.transform.position += windForce;
	}
}
