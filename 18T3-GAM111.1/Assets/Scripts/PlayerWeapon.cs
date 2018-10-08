using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	public float timer;
	public GameObject bullet;
	public float bulletRange;

	public enum WeaponType { Standard, other }; // Still need to add more weapons
	public WeaponType weaponType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0)
		{
			timer -= Time.deltaTime;
		}
		if (timer < 0)
		{
			if (Input.GetAxis("HorizontalShoot") > 0.25f)
			{
				Shoot(Vector2.right);
			}
			else if (Input.GetAxis("HorizontalShoot") < -0.25f)
			{
				Shoot(Vector2.left);
			}
			else if (Input.GetAxis("VerticalShoot") > 0.25f)
			{
				Shoot(Vector2.up);
			}
			else if (Input.GetAxis("VerticalShoot") < -0.25f)
			{
				Shoot(Vector2.down);
			}
		}
	}

	public void Shoot(Vector2 direction)
	{
		GameObject projectile;

		projectile = Instantiate(bullet, this.transform.position, this.transform.rotation);

		projectile.GetComponent<Bullet>().moveDirection = direction;
		timer = 1;
		Destroy(projectile, 2);
	}
}
