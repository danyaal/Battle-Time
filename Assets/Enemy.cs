using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int HP = 20;

	// Update is called once per frame
	void Update () {

		// Check if dead
		if(HP <= 0) {
			Destroy(this.gameObject);
		}
		
	}
	
}
