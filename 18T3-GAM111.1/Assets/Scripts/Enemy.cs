using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Health myHealth;
	public enum EnemyType { Follow, Turret, Patrol };
	public EnemyType type;

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if (myHealth.currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject other = collision.gameObject;

		if (other.CompareTag("Bullet"))
		{
			myHealth.ChangeHealth(-1);
			Destroy(other);
		}
	}
}
