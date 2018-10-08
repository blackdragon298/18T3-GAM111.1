using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(moveDirection * 10 * Time.deltaTime);
	}

	public void ParticleTrigger()
	{
		GetComponent<ParticleSystem>().Play();
	}
}
