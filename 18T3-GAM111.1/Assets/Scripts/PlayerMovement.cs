using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public bool speedBoost;
	public float speedBoostTimer;

	// Update is called once per frame
	void Update()
	{
		if (speedBoostTimer > 0)
		{
			speedBoostTimer -= Time.deltaTime;
		}
		else
		{
			speedBoost = false;
		}
		if (GetComponent<Health>().isAlive)
		{
			Vector2 movement = new Vector2(0, 0);
			// Horizontal Movement
			if (Input.GetAxis("Horizontal") > 0.25f)
			{
				movement.x = 1;
			}
			else if (Input.GetAxis("Horizontal") < -0.25f)
			{
				movement.x = -1;
			}
			else
			{
				movement.x = 0;
			}

			// Vertical Movement
			if (Input.GetAxis("Vertical") > 0.25f)
			{
				movement.y = 1;
			}
			else if (Input.GetAxis("Vertical") < -0.25f)
			{
				movement.y = -1;
			}
			else
			{
				movement.y = 0;
			}

			// Speed Boost Check
			if (speedBoost)
			{
				GetComponent<Rigidbody2D>().AddForce(movement * speed * 100 * 1.5f);
			}
			else
			{
				GetComponent<Rigidbody2D>().AddForce(movement * speed * 100);
			}

		}
	}

	public void ActivateSpeedBoost()
	{
		speedBoost = true;
		speedBoostTimer = 5;
	}
}
