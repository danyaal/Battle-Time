using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
		
	Vector3 destination;

	int waterPP = 10;
	static int waterCount = 0;

	bool isPlayerOwned;
	
	// Use this for initialization
	void Start() {
		if(waterCount < waterPP) {
			waterCount++;
		} else {
			Destroy(this.gameObject);
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
}
