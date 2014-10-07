using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	Vector3 destination;

	int firePP = 50;
	static int fireCount = 0;

	bool isPlayerOwned = false;

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

	public void setAttackDestination(Vector3 moveTo, bool isPlayer) {
		destination = moveTo;
		isPlayerOwned = isPlayer;
	}

	void OnTriggerEnter(Collider col) {
		if(col.CompareTag("player") && !isPlayerOwned) {
			// Remove HP From Player
			GameObject player = GameObject.FindGameObjectWithTag("player");
			Player pScript = player.GetComponent<Player>();
			pScript.HP--;
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
			eScript.HP--;
			// Destroy this
			Destroy(this.gameObject);
		}
	}


}
