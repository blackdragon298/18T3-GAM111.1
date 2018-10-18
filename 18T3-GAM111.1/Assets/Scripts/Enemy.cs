using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	Health myHealth;
	public enum EnemyType { Follow, FastFollow, Turret };
	public EnemyType type;
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start()
	{
		myHealth = GetComponent<Health>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		spriteRenderer.sprite = sprites[(int)type];

		if (myHealth.currentHealth <= 0)
		{
			GameObject.FindObjectOfType<ScoreManager>().IncreaseScore(1);
			Destroy(this.gameObject);

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject other = collision.gameObject;


	}
}
