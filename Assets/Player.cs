﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject FirePrefab;
	public GameObject WaterPrefab;
	public GameObject GrassPrefab;
	Vector3 mouseLocation;

	int HP = 20;

	// Update is called once per frame
	void Update () {

		// Get mouse pos
		mouseLocation = Camera.main.camera.ScreenToWorldPoint(Input.mousePosition);
		mouseLocation.z = -1;

		// Move player at coordinates
		Vector3 moveTo = this.transform.position;
		moveTo.x = mouseLocation.x - this.transform.position.x;
		moveTo.y = mouseLocation.y - this.transform.position.y;
		moveTo.z = 0;

		this.transform.position += moveTo*Time.deltaTime;

		// Attack Listeners
		if(Input.GetKeyDown("w")) {
			Fire(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("a")) {
			Water(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("s")) {
			Grass(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("d")) {
			Punch();
		}

	}

	void Fire(float X, float Y) {
		GameObject fire = Instantiate (FirePrefab) as GameObject;
		fire.transform.position = this.transform.position;

		Fire fScript = fire.GetComponent<Fire>();

		Vector3 moveTo = this.transform.position;
		moveTo.x = X;
		moveTo.y = Y;
		moveTo.z = 0;

		fScript.setAttackDestination(moveTo);

	}

	void Water(float X, float Y) {
		GameObject water = Instantiate (WaterPrefab) as GameObject;
		water.transform.position = this.transform.position;

		Water wScript = water.GetComponent<Water>();

		Vector3 moveTo = this.transform.position;
		moveTo.x = X;
		moveTo.y = Y;
		moveTo.z = 0;

		wScript.setAttackDestination(moveTo);

	}

	void Grass(float X, float Y) {
		GameObject grass = Instantiate (GrassPrefab) as GameObject;
		grass.transform.position = this.transform.position;

		Grass gScript = grass.GetComponent<Grass>();

		Vector3 moveTo = this.transform.position;
		moveTo.x = X;
		moveTo.y = Y;
		moveTo.z = 0;
		
		gScript.setAttackDestination(moveTo);
	}

	void Punch() {
		print ("Punch");
	}

}
