using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class sharkScript : MonoBehaviour {

	Vector3 pos;
	Quaternion rot;
	Vector3 dir;

	// Use this for initialization
	void Start () {
		pos = GetComponent<Transform> ().position;
		//rot = GetComponent<Transform> ().rotation;
		dir.Set(0,0,1);
		StartCoroutine (findDir ());
	}
	
	// Update is called once per frame
	void Update () {		

		pos += dir * 0.05f;
		if (pos.y > 49.3) pos.y = 49.3f;
		if (pos.y < 1) pos.y = 1;

		GetComponent<Transform> ().position = pos;

		rot.SetLookRotation (dir);
		GetComponent<Transform> ().rotation = rot;



	}

	IEnumerator findDir (){

		while (true) {

			int n = Random.Range (1, 7);

			if (n == 1) {
				dir.x += 0.01f;
				dir.y -= 0.005f;
				dir.z -= 0.005f;
			}
			if (n == 2) {
				dir.x -= 0.01f;
				dir.y += 0.005f;
				dir.z += 0.005f;
			}
			if (n == 3) {
				dir.x -= 0.005f;
				dir.y += 0.01f;
				dir.z -= 0.005f;
			}
			if (n == 4) {
				dir.x += 0.005f;
				dir.y -= 0.01f;
				dir.z += 0.005f;
			}
			if (n == 5) {
				dir.x -= 0.005f;
				dir.y -= 0.005f;
				dir.z += 0.01f;
			}
			if (n == 6) {
				dir.x += 0.005f;
				dir.y += 0.005f;
				dir.z -= 0.01f;
			}

			if (dir.x > 1)
				dir.x = 1;
			if (dir.x < -1)
				dir.x = -1;
			if (dir.y > 0.3)
				dir.y = 0.3f;
			if (dir.y < -0.3)
				dir.y = -0.3f;
			if (dir.z > 1)
				dir.z = 1;
			if (dir.z < -1)
				dir.z = -1;

			//Debug.Log ("dir = " + dir.ToString());
			yield return new WaitForSeconds (0.1f);
			print (Time.time);
		}
		}
}
