using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
		
	Vector3 destination;

	int waterPP = 10;
	static int waterCount = 0;
	static int waterCountEnemy = 0;

	bool isPlayerOwned;
	
	// Use this for initialization
	void Start() {
		if(isPlayerOwned) {
			if(waterCount < waterPP) {
				waterCount++;
			} else {
				Destroy(this.gameObject);
			}
		} else {
			if(waterCountEnemy < waterPP) {
				waterCountEnemy++;
			} else {
				Destroy(this.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		// Move attack position
//		destination = destination.normalized;
		this.transform.position += destination*(Time.deltaTime*0.001f);

		// Check to see if fire left the map
		if(Camera.main.WorldToViewportPoint(this.transform.position).x<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y<0f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).x>1f ||
		   Camera.main.WorldToViewportPoint(this.transform.position).y>1f) {
			Destroy(this.gameObject);
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
			pScript.HP-=2*2;
			GameObject playerhp = GameObject.FindGameObjectWithTag("playerhp");
			Vector3 a = Vector3.zero;
			a.x = 0.1f;
			playerhp.transform.localScale -= a;
			// Destroy this
			Destroy(this.gameObject);
		} else if(col.CompareTag("fire")) {
			// Destroy fire
			Fire fire = col.GetComponent<Fire>();
			Destroy(fire.gameObject);
			// Destroy this
			Destroy(this.gameObject);
		} else if(col.CompareTag("grass")) {
			// Destroy grass
			// Destroy this
			Destroy(this.gameObject);
		} else if(col.CompareTag("water")) {
			// Destroy water
			Water water = col.GetComponent<Water>();
			Destroy(water.gameObject);
			// Destroy this
			Destroy(this.gameObject);
		} else if(col.CompareTag("enemy") && isPlayerOwned) {
			// Remove HP From enemy
			GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
			Enemy eScript = enemy.GetComponent<Enemy>();
			eScript.HP-=2;
			GameObject enemyhp = GameObject.FindGameObjectWithTag("enemyhp");
			Vector3 a = Vector3.zero;
			a.x = 0.1f*2;
			enemyhp.transform.localScale -= a;
			// Destroy this
			Destroy(this.gameObject);
		}
	}

}
