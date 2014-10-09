using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Vector3 mouseLocation;
	
	public GameObject FirePrefab;
	public GameObject WaterPrefab;
	public GameObject GrassPrefab;
	public int HP = 20;

	// Update is called once per frame
	void Update () {

		// Get mouse pos
		mouseLocation = Camera.main.camera.ScreenToWorldPoint(Input.mousePosition);
		mouseLocation.z = -1;

		// Move player to coordinates
		Vector3 moveTo = this.transform.position;
		moveTo.x = mouseLocation.x - this.transform.position.x;
		moveTo.y = mouseLocation.y - this.transform.position.y;
		moveTo.z = 0;

		Vector3 whereTo = this.transform.position;
		whereTo += moveTo*Time.deltaTime;
		if(System.Math.Abs(whereTo.x) > 16.5f/2f) {
			moveTo.x = 0;
		}
		if(System.Math.Abs(whereTo.y) > 9.5f/2f) {
			moveTo.y = 0;
		}

		this.transform.position += moveTo*Time.deltaTime;

		// Attack Listeners
		if(Input.GetKeyDown("w")) {
			Fire(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("a")) {
			Water(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("s")) {
			Grass(moveTo.x, moveTo.y);
		} else if(Input.GetKeyDown("d")) {
			Dash();
		}

		// Check if dead
		if(HP <= 0) {
			Destroy(this.gameObject);

			Fire fScript = FirePrefab.GetComponent<Fire>();
			fScript.Reload();

			Water wScript = WaterPrefab.GetComponent<Water>();
			wScript.Reload();

			Grass gScript = GrassPrefab.GetComponent<Grass>();
			gScript.Reload();

			GameObject ew = GameObject.FindGameObjectWithTag("enemywin");
			ew.guiText.enabled = true;
			GameObject sb = GameObject.FindGameObjectWithTag("spacebar");
			sb.guiText.enabled = true;

			Main m = Camera.main.camera.GetComponent<Main>();
			m.gameIsOver();

			GameObject e = GameObject.FindGameObjectWithTag("enemy");
			e.GetComponent<Player>().HP = 100000;
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

		fScript.setAttackDestination(moveTo, true);

	}

	void Water(float X, float Y) {
		GameObject water = Instantiate (WaterPrefab) as GameObject;
		water.transform.position = this.transform.position;

		Water wScript = water.GetComponent<Water>();

		Vector3 moveTo = this.transform.position;
		moveTo.x = X;
		moveTo.y = Y;
		moveTo.z = 0;

		wScript.setAttackDestination(moveTo, true);

	}

	void Grass(float X, float Y) {
		GameObject grass = Instantiate (GrassPrefab) as GameObject;
		grass.transform.position = this.transform.position;

		Grass gScript = grass.GetComponent<Grass>();

		Vector3 moveTo = this.transform.position;
		moveTo.x = X;
		moveTo.y = Y;
		moveTo.z = 0;
		
		gScript.setAttackDestination(moveTo, true);
	}

	void Dash() {
		Vector3 mousePos = mouseLocation;
		mousePos.x = mousePos.x - this.transform.position.x;
		mousePos.y = mousePos.y - this.transform.position.y;
		mousePos.z = 0;
		mousePos = mousePos.normalized;
		this.transform.position += mousePos;
	}

}
