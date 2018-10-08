using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public enum HealthPackSize { Standard, Large }
	public HealthPackSize size;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Trigger(GameObject other)
	{
		Health health = other.GetComponent<Health>();

		switch (size)
		{
			case HealthPackSize.Standard:
				health.ChangeHealth(1);
				break;
			case HealthPackSize.Large:
				health.ChangeHealth(2);
				break;
			default:
				break;
		}
	}
}
