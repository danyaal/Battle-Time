using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel("_Scene1");
		}
	}
}
