using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	public float timer;
	public float respawnTime;
	MeshRenderer mesh;
	CircleCollider2D circleCollider;

	public enum HealthPackSize { Standard, Large}
	public HealthPackSize size;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer>();
		circleCollider = GetComponent<CircleCollider2D>();
		//mesh.enabled = true;
		//circleCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			mesh.enabled = true;
			circleCollider.enabled = true;
		}
	}

	public void Trigger(GameObject other)
	{
		Health health = other.GetComponent<Health>();
		
		switch (size)
		{
			case HealthPackSize.Standard:
				health.ChangeHealth(10);
				mesh.enabled = false;
				circleCollider.enabled = false;
				timer = respawnTime;
				break;
			case HealthPackSize.Large:
				health.ChangeHealth(20);
				mesh.enabled = false;
				circleCollider.enabled = false;
				timer = respawnTime;
				break;
			default:
				break;
		}
	}
}
