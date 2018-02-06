using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


	GameObject someObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit, 2.0f)){
			//Debug.Log(hit.collider.name + ", " + hit.distance);
		}

		if (Input.GetMouseButtonDown(0) && hit.collider.name == "Cube_box"){
			Debug.Log("Hit!!!!!");
			someObject = GameObject.Find(hit.collider.name);
			someObject.GetComponent<Rigidbody>().AddForceAtPosition(ray.direction*1000f, hit.point);
		}
	}	


}
