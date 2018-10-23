using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

	public GameObject bonesScreen;
	public GameObject player;
	public GameObject playerCam;
	public GameObject guiCam;
	public GameObject tempScreen;
	public int state;
	public int currState;

	// Use this for initialization
	void Start () {
		if (gameObject.scene.name == "main") {
			state = 1;
		} else if (gameObject.scene.name == "pause") {
			state = 2;
		} else if (gameObject.scene.name == "gameover") {
			state = 3;
		} else if (gameObject.scene.name == "level1") {
			state = 5;
		} else if (gameObject.scene.name == "sandbox") {
			state = 10;
			bonesScreen = GameObject.FindWithTag ("Bones");
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 1:
		case 2:
		case 3:
			break;
		case 4:
			if (Input.GetKeyDown (KeyCode.Tab)) {
				//change the state
				state = currState;

				//make the bone screen disappear
				bonesScreen.transform.GetChild (0).gameObject.SetActive (false);

				//makes the camera for the gui disappear
				guiCam.SetActive (false);

				//unfreeze the player
				player.SetActive (true);
				playerCam.SetActive (true);
			}
			break;
		case 5:
			break;
		case 10:
			if (Input.GetKeyDown (KeyCode.Tab)) {
				//set the current state
				currState = state;

				//change the state
				state = 4;

				//make the bone screen appear in front of the player
				bonesScreen.transform.GetChild (0).gameObject.SetActive (true);
				bonesScreen.transform.position = tempScreen.transform.position;
				bonesScreen.transform.rotation = tempScreen.transform.rotation;

				//makes the camera for the gui appear
				guiCam.SetActive (true);
				guiCam.transform.position = playerCam.transform.position;
				guiCam.transform.rotation = playerCam.transform.rotation;

				//freeze the player
				player.SetActive (false);
				playerCam.SetActive (false);
			}
			break;
		}
	}
}
