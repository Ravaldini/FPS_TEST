using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_flip : MonoBehaviour {

	public GameObject player;
	private Transform tr;

	// Use this for initialization
	void Start () {		
		/*
		tr = GetComponent<Transform>();
		Debug.Log(tr.transform.position.x);

		tr.transform.position.Set (1000f, 0f, 0f);
		Debug.Log(tr.transform.position.x);*/
	}
	
	// Update is called once per frame
	void Update () {
		

		if (player.transform.position.y <= 49.2) {
			//Debug.Log ("Under water now!");
		}

		if (player.transform.position.y > 49.2) {
			//Debug.Log ("Back on air!");
		}

	}
}
