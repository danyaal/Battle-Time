using UnityEngine;
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

		this.transform.position += moveTo*(Time.deltaTime*1.5f);

		// Attack Listeners
		if(Input.GetKeyDown("w")) {
			Fire(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("a")) {
			Water();
		} else if(Input.GetKeyDown("s")) {
			Grass();
		} else if(Input.GetKeyDown("d")) {
			Punch();
		}

	}

	void Fire(float X, float Y) {
		GameObject fire = Instantiate (FirePrefab) as GameObject;
		Vector3 firePos = this.transform.position;

		fire.transform.position = firePos;

//		Vector3 moveTo = this.transform.position;
//		moveTo.x = X - firePos.x;
//		moveTo.y = Y - firePos.y;
//		moveTo.z=0;
//		firePos += moveTo*Time.deltaTime*2;
	}

	void Water() {
		GameObject water = Instantiate (WaterPrefab) as GameObject;
		Vector3 waterPos = this.transform.position;
		
		water.transform.position = waterPos;
	}

	void Grass() {
		GameObject grass = Instantiate (GrassPrefab) as GameObject;
		Vector3 grassPos = this.transform.position;
		
		grass.transform.position = grassPos;
	}

	void Punch() {
		print ("Punch");
	}

}
