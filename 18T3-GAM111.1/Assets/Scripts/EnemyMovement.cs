using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	Vector3 direction;
	GameObject player;
	Enemy enemy;
	Rigidbody2D rb2d;
	public float speed;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		enemy = GetComponent<Enemy>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		direction = player.transform.position - this.transform.position;

		if (player.GetComponent<Health>().GetHealth() <= 0)
		{
			speed = 0;
		}

		switch (enemy.type)
		{
			case Enemy.EnemyType.Follow:
				//transform.Translate(direction.normalized * speed * Time.deltaTime);
				if (Vector2.Distance(this.transform.position, player.transform.position) < 10)
				{
					rb2d.AddForce(direction.normalized * speed * 100);
				}
				break;
			case Enemy.EnemyType.FastFollow:
				if (Vector2.Distance(this.transform.position, player.transform.position) < 10)
				{
					rb2d.AddForce(direction.normalized * speed * 150);
				}
				break;
			case Enemy.EnemyType.Turret:
				break;
			default:
				break;
		}
	}
}
