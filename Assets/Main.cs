using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject PlayerPrefab;
	public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {

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

}
