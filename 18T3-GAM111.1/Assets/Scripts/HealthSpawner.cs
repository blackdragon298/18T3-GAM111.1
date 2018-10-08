﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour {

	public float timer;
	public float respawnTime;
	public GameObject spawnObj;
	public GameObject spawnInstance;
	public HealthPickup.HealthPackSize spawnSize;

	bool respawning;

	// Use this for initialization
	void Start()
	{
		spawnInstance = Instantiate(spawnObj, this.transform.position, this.transform.rotation);
		spawnInstance.GetComponent<HealthPickup>().size = spawnSize;
		respawning = false;
	}

	// Update is called once per frame
	void Update()
	{
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
			spawnInstance = Instantiate(spawnObj, this.transform.position, this.transform.rotation);
			spawnInstance.GetComponent<HealthPickup>().size = spawnSize;
			respawning = false;
		}
	}
}
