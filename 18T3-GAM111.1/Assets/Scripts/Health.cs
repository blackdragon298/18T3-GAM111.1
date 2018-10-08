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

		// Health Pack Detection
		if (other.CompareTag("HealthPack"))
		{
			HealthPickup healthPack = other.GetComponent<HealthPickup>();
			if (currentHealth < maxHealth)
			{
				healthPack.Trigger(this.gameObject);
			}

		}

		if (this.CompareTag("Enemy"))
		{
			if (other.CompareTag("Bullet"))
			{
				ChangeHealth(-1);
				other.GetComponent<Bullet>().ParticleTrigger();
				Destroy(other, 0.2f);
			}
		}
	}

	public void ChangeHealth(int change)
	{
		currentHealth += change;
	}

	public int GetHealth()
	{
		return currentHealth;
	}
}
