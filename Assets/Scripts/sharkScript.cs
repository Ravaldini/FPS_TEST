using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class sharkScript : MonoBehaviour {

	Vector3 pos;
	Quaternion rot;
	Vector3 dir;
	float speed = 0.3f;

	GameObject player;
	bool onMyWay = false;
	Vector3 wayPoint;
	Vector3 wayDir;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("FPSController");

		pos = GetComponent<Transform> ().position;
		//rot = GetComponent<Transform> ().rotation;
		dir.Set(-0.7f, 0, -0.7f);
		StartCoroutine (findDir ());

	}
	

	void Update () {		

		pos += dir * speed;
		if (pos.y > 49.3) pos.y = 49.3f;
		if (pos.y < 1) pos.y = 1;

		GetComponent<Transform> ().position = pos;

		rot.SetLookRotation (dir);
		GetComponent<Transform> ().rotation = rot;



	}

	IEnumerator findDir (){


		//Выбираем точку в квадрате игрока.
		//Начинаем движение.
		//Поворот до нужного направления.
		//Если коллизия, выполняем поворот влево или вправо, пока коллизия не исчезнет.
		//Затем выбираем другую точку.
		//Если достигли точки, выбираем другую точку.
		while (true) {
			
			if (!onMyWay) {		
			
				float x = Random.Range (player.transform.position.x - 10, player.transform.position.x + 10);
				float y = Random.Range (15, 49.3f);
				float z = Random.Range (player.transform.position.z - 10, player.transform.position.z + 10);
				;
				wayPoint.Set (x, y, z);
				Debug.Log ("wayPoint = " + wayPoint.ToString ());

				onMyWay = true;

				wayDir = wayPoint - pos;
				wayDir.Normalize();

				Debug.Log ("wayDir = " + wayDir.ToString ());

			}

			wayDir = wayPoint - pos;
			wayDir.Normalize();

			bool settingX = false;

			if (dir.x > wayDir.x) {
				dir.x -= 0.005f;
				//dir.y += 0.001f;
				//dir.z += 0.005f;
				//dir.Normalize ();

				settingX = true;
			}
			else settingX = false;
				
			if (dir.x < wayDir.x && !settingX) {
				dir.x += 0.005f;
				//dir.y -= 0.001f;
				//dir.z -= 0.005f;
				//dir.Normalize ();

				settingX = true;
			}
			else settingX = false;

			if (dir.y > wayDir.y) {
				//dir.x += 0.001f;
				dir.y -= 0.005f;
				//dir.z += 0.001f;
				//dir.Normalize ();
			}

			if (dir.y < wayDir.y) {
				//dir.x -= 0.001f;
				dir.y += 0.005f;
				//dir.z -= 0.001f;
				//dir.Normalize ();
			}

			if (dir.z > wayDir.z && !settingX) {
				//dir.x += 0.005f;
				//dir.y += 0.001f;
				dir.z -= 0.005f;
				//dir.Normalize ();
			}

			if (dir.z < wayDir.z && !settingX) {
				//dir.x -= 0.005f;
				//dir.y -= 0.001f;
				dir.z += 0.005f;
				//dir.Normalize ();
			}		



			if (pos.x > wayPoint.x - 0.5f && pos.x < wayPoint.x + 0.5f  && pos.y > wayPoint.y - 0.5f && pos.y < wayPoint.y + 0.5f && pos.z > wayPoint.z - 0.5f && pos.z < wayPoint.z + 0.5f)
				onMyWay = false;


			yield return new WaitForSeconds (0.05f);
		}
	}
}
