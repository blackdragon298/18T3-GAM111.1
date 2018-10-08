using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Vector3 direction;
	GameObject player;

	public float speed;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		direction = player.transform.position - this.transform.position;

		transform.Translate(direction.normalized * speed * Time.deltaTime);
	}
}
