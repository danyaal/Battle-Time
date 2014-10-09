using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	float i = 0f;

	void FixedUpdate() {
		if(i >= 2) {
			Application.LoadLevel("_Intro");
		}
		i += Time.deltaTime;
	}

}