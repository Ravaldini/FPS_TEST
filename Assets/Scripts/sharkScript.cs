using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class sharkScript : MonoBehaviour {

	Vector3 pos;
	Quaternion rot;
	int degRot = 0;
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

		dir.Set(-0.7f, 0, -0.7f);

		StartCoroutine (findDir ());

	}
	

	private void FixedUpdate () {		

		//Движение
		pos += dir * speed;

		//Проверка высоты
		if (pos.y > 49.3) pos.y = 49.3f;
		if (pos.y < 1) pos.y = 1;

		//Проверка прибытия в точку
		if (pos.x > wayPoint.x - 0.5f && pos.x < wayPoint.x + 0.5f  && pos.y > wayPoint.y - 0.5f && pos.y < wayPoint.y + 0.5f && pos.z > wayPoint.z - 0.5f && pos.z < wayPoint.z + 0.5f)
			onMyWay = false;
		
		GetComponent<Transform> ().position = pos;

		//Создаем кватернион по вектору и устанавливаем на объект
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
			}



			float vAng = Vector3.Angle(dir, wayDir);
			//Debug.Log ("vAng = " + vAng);

			if (vAng > 180)
				degRot -= 1;

			if (vAng < 180)
				degRot += 1;

			if (degRot > 360)
				degRot -= 360;

			if (degRot < 0)
				degRot += 360;
			
			//Debug.Log ("degRot = " + degRot);

			float f = degRot * 0.0174532f;

			dir.x = Mathf.Cos (f) - Mathf.Sin (f);
			dir.z = Mathf.Sin (f) + Mathf.Cos (f);


			if (dir.y > wayDir.y) {
				dir.y -= 0.005f;
			}

			if (dir.y < wayDir.y) {				
				dir.y += 0.005f;
			}


			yield return new WaitForSeconds (0.01f);
		}
	}
}
