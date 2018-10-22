using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneEffectsController : MonoBehaviour {
	//broken bone trackers
	public Dictionary<string, int> brokenBones = new Dictionary<string, int>();

	public int maxBrokenBones = 3;
	public int armLegCount = 2;

	//weather controller tied to same object
	public WeatherController thisWeatherController;


	// Use this for initialization
	void Start () {
		brokenBones.Add ("skull", 0);
		brokenBones.Add ("neck", 0);
		brokenBones.Add ("back", 0);
		brokenBones.Add ("ribs", 0);
		brokenBones.Add ("arms", 0);
		brokenBones.Add ("legs", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Alpha1)) {
			BreakBone ("ribs");
			Debug.Log ("Breaking ribs to increase windspeed");
		} else if (Input.GetKeyUp(KeyCode.Alpha2)) {
			BreakBone ("ribs", false);
			Debug.Log ("Breaking ribs to decrease windspeed");
		}
	}

	//Method to break a specific bone
	bool BreakBone (string bone, bool increase = true) {
		int breakLimit = maxBrokenBones;

		//arms and legs have a higher limit than other bones
		if (bone == "arms" || bone == "legs") {
			breakLimit *= armLegCount;
		}

		//check if bone has reached break limit
		if (brokenBones[bone] + 1 >= breakLimit) {
			return false;
		} else {
			brokenBones[bone]++;
		}

		switch (bone) {
		case "arms":
			thisWeatherController.ChangePrecipitation (increase);			
			break;
		case "legs":
			thisWeatherController.ChangeTemperature (increase);
			break;
		case "skull":

			break;
		case "neck":

			break;
		case "back":

			break;
		case "ribs":
			thisWeatherController.ChangeWind (increase);
			break;
		}

		return true;
	}
}
