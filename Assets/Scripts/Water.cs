using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player.transform.position.y <= 49.2) {
			//Debug.Log ("Under water now!");
			//System.
		}

		if (player.transform.position.y > 49.2) {
			//Debug.Log ("Back on air!");
		}
	}
}
