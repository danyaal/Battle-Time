using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	float timePassed = 0;
	float blinkTime = 0.8f;

	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;

		if(timePassed > blinkTime) {

			GameObject sb = GameObject.FindGameObjectWithTag("spacebar");

			if(sb.guiText.enabled) {
				sb.guiText.enabled = false;
			} else {
				sb.guiText.enabled = true;
			}

			timePassed = 0;
		}

		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel("_Scene1");
		}

	}
}
