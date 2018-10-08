using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Vector3 direction;
	GameObject player;
	Enemy enemy;
	public float speed;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		enemy = this.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		direction = player.transform.position - this.transform.position;

		if (player.GetComponent<Health>().GetHealth() <= 0)
		{
			speed = 0;
		}

		switch (enemy.type)
		{
			case Enemy.EnemyType.Follow:
				transform.Translate(direction.normalized * speed * Time.deltaTime);
				break;
			case Enemy.EnemyType.Turret:
				break;
			case Enemy.EnemyType.Patrol:
				break;
			default:
				break;
		}
	}
}
