using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public enum PickupType { Health, Speed }
	public PickupType type;
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	private ParticleSystem particle;

	// Use this for initialization
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		particle = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		spriteRenderer.sprite = sprites[(int)type];
	}

	public void Trigger(GameObject other)
	{
		ParticleSystem.MainModule particleMain = particle.main;

		switch (type)
		{
			case PickupType.Health:
				Health health = other.GetComponent<Health>();
				health.ChangeHealth(1);
				particleMain.startColor = Color.red;
				break;
			case PickupType.Speed:
				PlayerMovement move = other.GetComponent<PlayerMovement>();
				move.ActivateSpeedBoost();
				particleMain.startColor = Color.green;
				break;
			default:
				break;
		}

		spriteRenderer.enabled = false;
		particle.Play();
		Destroy(this.gameObject, 0.5f);
	}
}
