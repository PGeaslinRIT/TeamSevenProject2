using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

	public GameObject bonesScreen;
	public GameObject player;
	public GameObject playerCam;
	public GameObject guiCam;
	public int state;

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
				state = 10;
				bonesScreen.transform.GetChild (0).gameObject.SetActive (false);
				guiCam.SetActive (false);
				player.SetActive (true);
				playerCam.SetActive (true);
			}
			break;
		case 5:
			break;
		case 10:
			if (Input.GetKeyDown (KeyCode.Tab)) {
				state = 4;
				bonesScreen.transform.GetChild (0).gameObject.SetActive (true);
				bonesScreen.transform.position = player.transform.position;
				bonesScreen.transform.right = player.transform.right;

				//
				guiCam.SetActive (true);
				guiCam.transform.position = playerCam.transform.position;
				guiCam.transform.right = playerCam.transform.right;
				player.SetActive (false);
				playerCam.SetActive (false);
			}
			break;
		}
	}
}
