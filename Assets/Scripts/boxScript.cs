using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour {

	GameObject someObject;
	public bool inHands;
	public string attachedTo;

	// Use this for initialization
	void Start () {
		inHands = false;
		attachedTo = "none";
	}
	
	// Update is called once per frame
	void Update () {

		if (inHands) {
			someObject = GameObject.Find ("FPSController");
			transform.position = someObject.transform.position;
			GetComponent<BoxCollider> ().enabled = false;
		}
		else {
			GetComponent<BoxCollider> ().enabled = true;
		}

	}
}
