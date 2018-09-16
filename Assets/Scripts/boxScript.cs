using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour {

	GameObject someObject;
	public bool inHands;
	public string attachedTo;

    public bool inWater;

    Rigidbody rb;
    float waterlevel = 49.2f;

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
            rb.AddForce(0.35f * (waterlevel - transform.position.y) * Vector3.up, ForceMode.Impulse);

            float x = rb.velocity.x;
            if (x > 0) x -= 0.5f;
            if (x < 0) x += 0.5f;

            float y = rb.velocity.y;

            float z = rb.velocity.z;
            if (z > 0) z -= 0.5f;
            if (z < 0) z += 0.5f;

            rb.velocity.Set(x, y, z);
        }
        else
        {
            inWater = false;
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