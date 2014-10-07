﻿using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	Vector3 destination;

	int firePP = 50;
	static int fireCount = 0;

	// Use this for initialization
	void Start() {
		if(fireCount < firePP) {
			fireCount++;
		} else {
			Destroy(this.gameObject);
		}
	}
	
	void Update () {

		// Move attack position
		destination = destination.normalized*10;
		this.transform.position += destination*(Time.deltaTime*2.5f);

		// Check to see if fire left the map
		if(Camera.main.WorldToViewportPoint(this.transform.position).x<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).x>1f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y>1f) {
			Destroy(this.gameObject);
		}

	}

	public void setAttackDestination(Vector3 moveTo) {
		destination = moveTo;
	}


}
