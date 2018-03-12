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
			//this.gameObject.layer = 8;
			someObject = GameObject.Find ("FPSController");
			GetComponent<Transform> ().position = someObject.transform.position;
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<Rigidbody> ().isKinematic = true;
		}
		else {
			//this.gameObject.layer = 0;
			GetComponent<BoxCollider> ().enabled = true;
			GetComponent<Rigidbody> ().isKinematic = false;
		}


	}
}