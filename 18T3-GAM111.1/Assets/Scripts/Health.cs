using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public bool isAlive;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
		{
			isAlive = false;
		}
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject other = collision.gameObject;
		if (this.CompareTag("Player"))
		{
			if (other.CompareTag("Enemy"))
			{
				ChangeHealth(-1);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject other = collision.gameObject;
		if (other.CompareTag("HealthPack"))
		{
			HealthPickup health = other.GetComponent<HealthPickup>();
			if (currentHealth < maxHealth)
			{
				health.Trigger(this.gameObject);
			}

		}
	}

	public void ChangeHealth(int change)
	{
		currentHealth += change;
	}
}
