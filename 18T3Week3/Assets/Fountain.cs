using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
	public GameObject spawnerObject;

	public float timer;
	public float spawnTime;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			SpawnObject();
			timer = spawnTime;
		}
	}

	public void SpawnObject()
	{
		GameObject obj;
		Vector2 spawnDirection = new Vector2(300, Random.Range(-20, 20f));
		obj = Instantiate(spawnerObject, this.gameObject.transform);
		obj.GetComponent<Rigidbody2D>().AddForce(spawnDirection);
	}
}
