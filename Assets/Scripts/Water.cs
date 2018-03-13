using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	GameObject player;
	GameObject shark;

	float waterLevel;

	// Use this for initialization
	void Start () {

		waterLevel = 49.2f;

		player = GameObject.Find ("FPSController");
		shark = GameObject.Find ("shark");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player.transform.position.y <= waterLevel) {
			//Debug.Log ("Under water now!");
			player.GetComponent<PlayerControl>().inWater = true;

		}

		if (shark.transform.position.y <= waterLevel) {
			//Debug.Log ("Under water now!");
			shark.GetComponent<sharkScript>().inWater = true;

		}

		if (player.transform.position.y > waterLevel) {
			//Debug.Log ("Back on air!");
			player.GetComponent<PlayerControl>().inWater = false;
		}

		if (shark.transform.position.y > waterLevel) {
			//Debug.Log ("Back on air!");
			shark.GetComponent<sharkScript>().inWater = false;
		}
	}
}
