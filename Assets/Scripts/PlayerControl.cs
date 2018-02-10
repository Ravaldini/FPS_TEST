using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


	GameObject someObject;
	string heldObject;

	// Use this for initialization
	void Start () {

		heldObject = "none";
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit; //Объект проверяющий столкновения луча
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Луч из центра камеры

		//Проверяем столкновения в пределах двух метров
		if (Physics.Raycast (ray, out hit, 2.0f)) {
			//Debug.Log(hit.collider.name + ", " + hit.distance);
		}

		//Курсор активируется если мы указываем на объект
		if (hit.collider != null) {
			//Debug.Log(hit.collider.name + ", " + hit.distance);

			if (hit.collider.name != "Terrain") {
				someObject = GameObject.Find ("Cursor");
				someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 15);
				someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 15);
			} else {
				someObject = GameObject.Find ("Cursor");
				someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 10);
				someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 10);
			}
		} else {
			someObject = GameObject.Find ("Cursor");
			someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 10);
			someObject.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 10);
		}


		//Действия по клику левой кнопкой мыши
		if (Input.GetMouseButtonDown (0)) {

			//Если что-то видим и оъект является кнопкой, нажимаем ее.
			if (hit.collider != null) {
				if (hit.collider.tag == "button") {
					//Нужно передать объекту сообщение.					
					Debug.Log ("I've pressed the button " + hit.collider.name);
				}
			}


			//Если руки не пустые и ничего не видим, пытаемся использовать предмет.
			if (heldObject != "none" && hit.collider == null) {
				//Нужно передать объекту сообщение.
				Debug.Log ("Try to use " + heldObject);
			}


			//Если руки пустые и что-то видим, поднимаем это.
			if (heldObject == "none" && hit.collider != null) {
				
				if (hit.collider.tag == "object") {
					heldObject = hit.collider.name;
					someObject = GameObject.Find (hit.collider.name);
					someObject.GetComponent<boxScript> ().inHands = true;
					//Нужно передать объекту флаг, что его несет игрок.
					//someObject.GetComponent<Rigidbody> ().AddForceAtPosition (ray.direction * 1000f, hit.point);
					Debug.Log ("Now i carry " + heldObject);
				}
					
			}

			//Если руки не пустые и что-то видим, пытаемся применить предмет к объекту.
			if (heldObject != "none" && hit.collider != null) {
				
				if (hit.collider.tag == "object") {					
					//someObject = GameObject.Find (hit.collider.name);
					//Нужно передать объекту имя предмета в руках.
					//someObject.GetComponent<Rigidbody> ().AddForceAtPosition (ray.direction * 1000f, hit.point);
					Debug.Log ("Use two objects: " + heldObject + " + " + hit.collider.name);
				}

			}






		}

		//Действия по клику правой кнопкой мыши
		if (Input.GetMouseButtonDown (1)) {

			//Если руки не пустые бросаем предмет.
			if (heldObject != "none") {				

				someObject = GameObject.Find (heldObject);
				someObject.GetComponent<boxScript> ().inHands = false;
				heldObject = "none";
				Debug.Log ("Now i carry " + heldObject);
			}

			//Если руки пустые и что-то видим, пинаем это.
			if (heldObject == "none" && hit.collider != null) {
				
				if (hit.collider.name == "Terrain") {
					Debug.Log ("Can't kick terrain");
				}

				if (hit.collider.tag == "object") {
					someObject = GameObject.Find (hit.collider.name);
					someObject.GetComponent<Rigidbody> ().AddForceAtPosition (ray.direction * 1000f, hit.point);
					Debug.Log ("Kick that " + hit.collider.name);
				}
			}			

		}	

	}
}
