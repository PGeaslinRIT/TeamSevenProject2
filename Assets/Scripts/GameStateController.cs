using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

	public GameObject bonesScreen;
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
			break;
		case 5:
			break;
		case 10:
			if (Input.GetKeyDown (KeyCode.Tab)) {
				state = 4;
				bonesScreen = GameObject.FindGameObjectWithTag ("Bones");
				bonesScreen.SetActive (true);
			}
			break;
		}
	}
}
