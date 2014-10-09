using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject FirePrefab;
	public GameObject WaterPrefab;
	public GameObject GrassPrefab;
	public int HP = 20;

	float timePassed=0f;
	float timeBetweenShoot = 0.1f;

	float changeTimeAI=0f;
	float timeBetweenChangeAI = 5f;

	// AI Flags
	bool chaser = false;
	bool runner = false;

	// Use this for initialization
	void Start () {
		// Initialize AI
		runner = true;
	}

	// Update is called once per frame
	void Update () {

		timePassed += Time.deltaTime;
		changeTimeAI += Time.deltaTime;

		// Consider changing strategy
		if(changeTimeAI > timeBetweenChangeAI) {
			if(Random.Range (1,4) == 1) {
				runner = true;
				chaser = false;
			} else {
				chaser = true;
				runner = false;
			}
			changeTimeAI = 0f;
		}

		GameObject player = GameObject.FindGameObjectWithTag("player");
		Vector3 moveTo = Vector3.zero;

		// Simulate AI
		if(chaser) {
			// Move player to coordinates
			moveTo.x = (player.transform.position.x) - this.transform.position.x;
			moveTo.y = (player.transform.position.y * 0.9f) - this.transform.position.y;
			moveTo.z = 0;
			
			this.transform.position += moveTo*Time.deltaTime;
		} else if(runner) {

			// Move player to coordinates
			moveTo.x = (player.transform.position.x * -1) - this.transform.position.x;
			moveTo.y = (player.transform.position.y * -1) - this.transform.position.y;
			moveTo.z = 0;

			this.transform.position += moveTo*Time.deltaTime;
		}

		// If so, do attack
		if(timePassed > timeBetweenShoot) {
			
			// Get info about player location
			double distance = System.Math.Sqrt(System.Math.Pow(player.transform.position.x + this.transform.position.x, 2) + System.Math.Pow(player.transform.position.y + this.transform.position.y, 2));
			
			// Shoot fire if within range in the x direction
			if(distance > 0.5f) {
				if(this.transform.position.y + 0.2 > player.transform.position.y && 
				   this.transform.position.y - 0.2 < player.transform.position.y) {
					
					Vector3 shootAt = this.transform.position;
					if(this.transform.position.x < player.transform.position.x) {
						shootAt.x = 1;
					} else {
						shootAt.x = -1;
					}
					shootAt.y = 0;
					shootAt.z = 0;
					
					Fire(shootAt);
					timePassed = 0f;
				}
				if(this.transform.position.x + 0.2 > player.transform.position.x && 
				   this.transform.position.x - 0.2 < player.transform.position.x) {
					
					Vector3 shootAt = this.transform.position;
					shootAt.x = 0;
					if(this.transform.position.y < player.transform.position.y) {
						shootAt.y = 1;
					} else {
						shootAt.y = -1;
					}
					shootAt.z = 0;
					
					Fire(shootAt);
					timePassed = 0f;
				}
			}
			// Shoot grass when player gets too close
			else if(distance < 1f) {
				Grass(player.transform.position);
				timePassed = 0f;
			}
			// Randomly drop water
			if(Random.Range(1, 100) == 7) {
				Water(moveTo);
				timePassed = 0f;
			}
		}
		
		// Check if dead
		if(HP <= 0) {
			Destroy(this.gameObject);
			Application.LoadLevel("_GameOver");
			Fire fScript = FirePrefab.GetComponent<Fire>();
			fScript.Reload();
			
			Water wScript = WaterPrefab.GetComponent<Water>();
			wScript.Reload();
			
			Grass gScript = GrassPrefab.GetComponent<Grass>();
			gScript.Reload();
		}
		
	}

	void Fire(Vector3 shootAt) {
		GameObject fire = Instantiate (FirePrefab) as GameObject;
		fire.transform.position = this.transform.position;
		
		Fire fScript = fire.GetComponent<Fire>();

		fScript.setAttackDestination(shootAt, false);
	}

	void Water(Vector3 shootAt) {
		GameObject water = Instantiate (WaterPrefab) as GameObject;
		water.transform.position = this.transform.position;
		
		Water wScript = water.GetComponent<Water>();
		
		wScript.setAttackDestination(shootAt, false);
	}

	void Grass(Vector3 shootAt) {
		GameObject grass = Instantiate (GrassPrefab) as GameObject;
		grass.transform.position = this.transform.position;
		
		Grass gScript = grass.GetComponent<Grass>();
		
		gScript.setAttackDestination(shootAt, false);
	}
	
}
