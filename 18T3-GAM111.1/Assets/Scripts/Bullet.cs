using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		moveDirection = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(moveDirection * Time.deltaTime);
	}
}
