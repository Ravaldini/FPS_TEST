using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour {

	GameObject someObject;
	public bool inHands;
	public string attachedTo;

    public bool inWater;

    Rigidbody rb;
    float waterlevel = 49.5f;

    // Use this for initialization
    void Start () {
		inHands = false;
		attachedTo = "none";

        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //Проверка нахождения под водой
        if (transform.position.y <= waterlevel)
        {
            //Debug.Log ("Under water now!");
            inWater = true;
            //rb.AddForce(0.05f * (waterlevel - transform.position.y) * Vector3.up, ForceMode.Impulse);
            rb.AddForce(0.25f * Vector3.up, ForceMode.Impulse);
            rb.drag = 0.5f;
            rb.angularDrag = 2.0f;
            
        }
        else
        {
            inWater = false;
            rb.drag = 0.0f;
            rb.angularDrag = 0.05f;
        }

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