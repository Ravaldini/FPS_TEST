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
		
		
	}
}
