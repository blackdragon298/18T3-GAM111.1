using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public int maxHealth;
	public int currentHealth;
	public bool isAlive;

	PlayerMovement playerMovement;

	// Use this for initialization
	void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		currentHealth = maxHealth;
		isAlive = true;
	}

	// Update is called once per frame
	void Update()
	{
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

		// Pickup Detection
		if (this.CompareTag("Player"))
		{
			if (other.CompareTag("Pickup"))
			{
				Pickup pickup = other.GetComponent<Pickup>();
				switch (pickup.type)
				{
					// Check criteria for pickup
					case Pickup.PickupType.Health:
						if (currentHealth < maxHealth)
						{
							pickup.Trigger(this.gameObject);
						}
						break;
					case Pickup.PickupType.Speed:
						if (playerMovement.speedBoost == false)
						{
							pickup.Trigger(this.gameObject);
						}
						break;
					default:
						break;
				}




				

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

			if (other.CompareTag("Missile"))
			{
				ChangeHealth(-2);
				other.GetComponent<Missile>().ParticleTrigger();
				Destroy(other);
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
