using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float timer;
	public float respawnTime;
	public GameObject spawnObj;
	public GameObject spawnInstance;
	public Enemy.EnemyType spawnType;

	bool respawning;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawnInstance && !respawning)
		{
			timer = respawnTime;
			respawning = true;
		}
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		if (!spawnInstance && timer <= 0)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		spawnInstance = Instantiate(spawnObj, this.transform.position, this.transform.rotation);
		respawning = false;
		spawnInstance.GetComponent<Enemy>().type = spawnType;
	}
}
