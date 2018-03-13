using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class sharkScript : MonoBehaviour {

	public bool inWater;

	Rigidbody m_RigidBody;
	Vector3 pos;
	Quaternion rot;
	int degRot = 0;
	Vector3 dir;
	float speed = 0.3f;
	int turnSpeed = 1;

	GameObject player;
	bool onMyWay = false;
	bool onHunt = false;

	Vector3 wayPoint;
	Vector3 wayDir;
	Vector3 lSide;
	Vector3 rSide;


	// Use this for initialization
	void Start () {

		inWater = true;

		m_RigidBody = GetComponent<Rigidbody>();

		player = GameObject.Find ("FPSController");

		pos = GetComponent<Transform> ().position;

		dir.Set(-0.7f, 0, -0.7f);

		StartCoroutine (findDir ());


	}

	void Update () {
		//Проверка прибытия в точку
		if (pos.x > wayPoint.x - 5 && pos.x < wayPoint.x + 5  && pos.y > wayPoint.y - 5 && pos.y < wayPoint.y + 5 && pos.z > wayPoint.z - 5 && pos.z < wayPoint.z + 5)
			onMyWay = false;

		//GetComponent<Transform> ().position = pos;

		//Создаем кватернион по вектору и устанавливаем на объект
		//rot.SetLookRotation (dir);
		//GetComponent<Transform> ().rotation = rot;

		if (player.GetComponent<PlayerControl> ().inWater) {
			onMyWay = false;
			onHunt = true;
			speed = 10f;
			turnSpeed = 1;
		} 
		else {
			onHunt = false;
			speed = 5f;
			turnSpeed = 1;
		}
			

	}

	private void FixedUpdate () {		

		//Движение

		//m_RigidBody.AddForce (wayDir * speed, ForceMode.Impulse);
		m_RigidBody.velocity = (dir * speed);



		//if (inWater)
			//m_RigidBody.AddForce(new Vector3(0, 2.2f, 0), ForceMode.Impulse);

		//pos += dir * speed;
		//Проверка высоты
		//if (pos.y > 49.3) pos.y = 49.3f;
		//if (pos.y < 1) pos.y = 1;

	}

	IEnumerator findDir (){


		//Выбираем точку в квадрате игрока.
		//Начинаем движение.
		//Поворот до нужного направления.
		//Если коллизия, выполняем поворот влево или вправо, пока коллизия не исчезнет.
		//Затем выбираем другую точку.
		//Если достигли точки, выбираем другую точку.
		while (true) {
			
			if (!onMyWay && !onHunt) {		
			
				//Ищем рандомную точку прибытия
				//Нужно переделать на генерацию с учетом суши
				float x = Random.Range (player.transform.position.x - 100, player.transform.position.x + 100);
				float y = Random.Range (15, 49.1f);
				float z = Random.Range (player.transform.position.z - 100, player.transform.position.z + 100);
				;
				wayPoint.Set (x, y, z);
				Debug.Log ("wayPoint = " + wayPoint.ToString ());

				onMyWay = true;
			}

			if (onHunt) {		

				//Устанавливаем координаты игрока
				wayPoint = player.GetComponent<Transform>().position;
				//Debug.Log ("wayPoint = " + wayPoint.ToString ());
			}

			//Находим вектор к точке прибытия
			wayDir = wayPoint - pos;
			wayDir.Normalize();
			//Debug.Log ("wayDir = " + wayDir);
			//m_RigidBody.AddTorque (wayPoint * turnSpeed);


			// Находим вектора смотрящие в стороны от направления движения акулы
			lSide.Set (-dir.z, dir.y, dir.x);
			rSide.Set (dir.z, dir.y, -dir.x);


			//Находим углы от боковых векторов до вектора в сторону точки прибытия
			float lAng = Vector3.Angle(lSide, wayDir);
			float rAng = Vector3.Angle(rSide, wayDir);
			//Debug.Log ("lAng = " + lAng);
			//Debug.Log ("rAng = " + rAng);

			//Если от левого бокового вектора угол больше, мы поворачиваем влево
			//Потому что справа налево повернуть остается меньше чем слева направо
			if (lAng > rAng)
				degRot -= turnSpeed;

			//Если от левого бокового вектора угол меньше, мы поворачиваем вправо
			if (lAng < rAng)
				degRot += turnSpeed;

			//Держим угол поворота в пределах 360 градусов
			if (degRot > 360)
				degRot -= 360;

			if (degRot < 0)
				degRot += 360;
			
			//Debug.Log ("degRot = " + degRot);




			//Переводим в радианы
			float f = degRot * 0.0174532f;

			//Считаем поворот для угла в радианах
			dir.x = Mathf.Cos (f) - Mathf.Sin (f);
			dir.z = Mathf.Sin (f) + Mathf.Cos (f);

			//Поднимаем или опускаем нос
			if (dir.y > wayDir.y) {
				dir.y -= 0.01f;
			}

			if (dir.y < wayDir.y) {				
				dir.y += 0.01f;
			}


			yield return new WaitForSeconds (0.01f);
		}

	}


	void OnCollisionEnter(Collision coll) {		

		if (coll.gameObject.name == "Terrain") {			
			
			//Debug.Log ("coll.contacts[0].point.x = " + coll.contacts[0].point.x);
			//Debug.Log ("coll.contacts[0].point.z = " + coll.contacts[0].point.z);

			//Vector3 nVec = coll.gameObject.GetComponent<Terrain> ().terrainData.GetInterpolatedNormal (coll.contacts[0].point.x, coll.contacts[0].point.z);
			//Debug.Log ("nVec = " + nVec.ToString ());
		}

		/*
		//Разворот
		dir = -dir;
		degRot += 180;
		//Держим угол поворота в пределах 360 градусов
		if (degRot > 360)
			degRot -= 360;

		if (degRot < 0)
			degRot += 360;
		*/
		//Сброс точки прибытия
		onMyWay = false;

	}



}
