using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

	Vector3 destination;

	int grassPP = 5;
	static int grassCount = 0;
	static bool isOnField = false;
	
	// Use this for initialization
	void Start() {
		if(grassCount < grassPP && !isOnField) {
			grassCount++;
			isOnField = true;
		} else {
			Destroy(this.gameObject);
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
			isOnField = false;
		}
		
	}
	
	public void setAttackDestination(Vector3 moveTo) {
		destination = moveTo;
	}
}
