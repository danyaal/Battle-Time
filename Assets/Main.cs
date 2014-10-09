using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject PlayerPrefab;
	public GameObject EnemyPrefab;

	bool isGameOver = false;
	float timePassed = 0;
	float blinkTime = 0.8f;

	// Use this for initialization
	void Start () {

		isGameOver = false;

		// Init player
		GameObject player = Instantiate (PlayerPrefab) as GameObject;
		Vector3 startPos = Vector3.zero;
		startPos.z = -1;
		startPos.x = -5;
		player.transform.position = startPos;

		// Init enemy
		GameObject enemy = Instantiate (EnemyPrefab) as GameObject;
		startPos = Vector3.zero;
		startPos.z = -1;
		startPos.x = 5;
		enemy.transform.position = startPos;
	}

	// Update is called once per frame
	void Update() {

		if(isGameOver) {
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
		}
		if (isGameOver && Input.GetKeyDown ("space")) {
			Application.LoadLevel("_Intro");
		}
	}

	public void gameIsOver() {
		isGameOver = true;
	}

}
