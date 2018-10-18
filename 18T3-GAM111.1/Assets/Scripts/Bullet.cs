using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	// "moveDirection" is given to the bulled when it is spawned
	public Vector2 moveDirection;

	// Update is called once per frame
	void Update()
	{
		transform.Translate(moveDirection * 10 * Time.deltaTime);
	}

	public void ParticleTrigger()
	{
		GetComponent<ParticleSystem>().Play();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// The problem that was encountered with collision detection 
		// was solved by adding a "Rigidbody2D" to the bullet prefab 

		GameObject other = collision.gameObject;
		if (other.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}
