using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float timer;
	public float respawnTime;
	public GameObject spawnObj;
	public GameObject spawnInstance;

	// Use this for initialization
	void Start () {
		spawnInstance = Instantiate(spawnObj, this.transform.position, this.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawnInstance)
		{
			timer = respawnTime;
		}
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		if (!spawnInstance && timer <= 0)
		{
			spawnInstance = Instantiate(spawnObj, this.transform.position, this.transform.rotation);
		}
	}
}
