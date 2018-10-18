using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
	public Transform target;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt(target.transform);

		transform.Translate(Vector3.forward * Time.deltaTime * 3);
	}

	public void ParticleTrigger()
	{
		GetComponent<ParticleSystem>().Play();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject other = collision.gameObject;
		if (other.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}
