using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

	Vector3 destination;

	int grassPP = 5;
	static int grassCount = 0;
	static int grassCountEnemy = 0;
	static bool isOnField = false;
	static bool isOnFieldEnemy = false;

	bool isPlayerOwned;
	
	// Use this for initialization
	void Start() {
		if(isPlayerOwned) {
			if(grassCount < grassPP && !isOnField) {
				grassCount++;
				isOnField = true;
			} else {
				Destroy(this.gameObject);
			}
		} else {
			if(grassCountEnemy < grassPP && !isOnFieldEnemy) {
				grassCountEnemy++;
				isOnFieldEnemy = true;
			} else {
				Destroy(this.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// Move attack position
		destination = destination.normalized*10;
		this.transform.position += destination*(Time.deltaTime*1f);

		// Scale attack
		Vector3 a = Vector3.zero;
		a.x = 0.05f;
		a.y = 0.05f;
		a.z = 0.05f;
		this.transform.localScale += a;
		
		// Check to see if fire left the map
		if(Camera.main.WorldToViewportPoint(this.transform.position).x<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).x>1f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y>1f) {
			Destroy(this.gameObject);
			if(isOnField) {
				isOnField = false;
			} else {
				isOnFieldEnemy = false;
			}
		}
		
	}
	
	public void setAttackDestination(Vector3 moveTo, bool isPlayer) {
		destination = moveTo;
		isPlayerOwned = isPlayer;
	}

	void OnTriggerEnter(Collider col) {
		if(col.CompareTag("player") && !isPlayerOwned) {
			// Remove HP From Player
			GameObject player = GameObject.FindGameObjectWithTag("player");
			Player pScript = player.GetComponent<Player>();
			pScript.HP-=3;
			GameObject playerhp = GameObject.FindGameObjectWithTag("playerhp");
			Vector3 a = Vector3.zero;
			a.x = 0.15f*8;
			playerhp.transform.localScale -= a;
		} else if(col.CompareTag("fire")) {
			// Destroy fire
			Fire fire = col.GetComponent<Fire>();
			Destroy(fire.gameObject);
		} else if(col.CompareTag("grass")) {
			// Destroy grass
			Grass grass = col.GetComponent<Grass>();
			Destroy(grass.gameObject);
			isOnFieldEnemy = false;
			// Destroy this
			Destroy(this.gameObject);
			isOnField = false;
		} else if(col.CompareTag("water")) {
			// Destroy water
			Water water = col.GetComponent<Water>();
			Destroy(water.gameObject);
		} else if(col.CompareTag("enemy") && isPlayerOwned) {
			// Remove HP From enemy
			GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
			Enemy eScript = enemy.GetComponent<Enemy>();
			eScript.HP-=3;
			GameObject enemyhp = GameObject.FindGameObjectWithTag("enemyhp");
			Vector3 a = Vector3.zero;
			a.x = 0.15f*8;
			enemyhp.transform.localScale -= a;
		}
	}

	public void Reload() {
		grassCount = 0;
		grassCountEnemy = 0;
	}
}
